using AutoMapper;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Domain.Models.Enums;
using EventsBasicANC.Models;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsBasicANC.Services
{
    public class FichaAppService : IFichaAppService
    {
        private readonly IFichaRepository _fichaRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;
        private int quantidadeFichasPorEvento = 10000;

        public FichaAppService(IFichaRepository fichaRepository, IMovimentacaoRepository movimentacaoRepository, IPagamentoRepository pagamentoRepository, IMapper mapper)
        {
            _fichaRepository = fichaRepository;
            _movimentacaoRepository = movimentacaoRepository;
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
        }

        public FichaViewModel Atualizar(FichaViewModel FichaViewModel)
        {
            var model = _fichaRepository.TrazerPorId(FichaViewModel.Id);

            double saldoAnterior = model.Saldo;

            double saldoDiferenca = model.Saldo > FichaViewModel.Saldo ? (model.Saldo - FichaViewModel.Saldo) : (FichaViewModel.Saldo - model.Saldo);

            MovimentacaoTipo movimentacaoTipo = model.Saldo > FichaViewModel.Saldo ? MovimentacaoTipo.Saida : MovimentacaoTipo.Entreda;

            var modelAtualizado = _mapper.Map(FichaViewModel, model);

            var fichaAtualizada = _mapper.Map<FichaViewModel>(_fichaRepository.Atualizar(modelAtualizado));

            if (saldoDiferenca != 0)
            {
                Movimentacao mov = new Movimentacao() { SaldoAnterior = saldoAnterior, MovimentacaoTipo = movimentacaoTipo, Valor = saldoDiferenca };
                _movimentacaoRepository.Criar(mov);
            }

            return fichaAtualizada;
        }

        public FichaViewModel Atualizar(FichaViewModel FichaViewModel, Guid id_pagamento, bool estorno = false, string movimentacaoObs = null)
        {

            var model = _fichaRepository.TrazerPorId(FichaViewModel.Id);

            double saldoAnterior = model.Saldo;

            double saldoDiferenca = model.Saldo > FichaViewModel.Saldo ? (model.Saldo - FichaViewModel.Saldo) : (FichaViewModel.Saldo - model.Saldo);

            MovimentacaoTipo movimentacaoTipo = model.Saldo > FichaViewModel.Saldo ? MovimentacaoTipo.Saida :
                                                estorno ? MovimentacaoTipo.Estorno :
                                                MovimentacaoTipo.Entreda;

            var modelAtualizado = _mapper.Map(FichaViewModel, model);

            var fichaAtualizada = _mapper.Map<FichaViewModel>(_fichaRepository.Atualizar(modelAtualizado));

            if (saldoDiferenca != 0)
            {
                Movimentacao mov = new Movimentacao()
                {
                    Id_ficha = model.Id,
                    SaldoAnterior = saldoAnterior,
                    Id_Pagamento = id_pagamento,
                    MovimentacaoTipo = movimentacaoTipo,
                    Observacao = movimentacaoObs
                };

                _movimentacaoRepository.Criar(mov);
            }

            return fichaAtualizada;
        }

        public IEnumerable<FichaViewModel> CriaFichasParaNovoEvento(Guid id_evento)
        {
            List<Ficha> fichasDoEvento = new List<Ficha>();
            List<Ficha> fichasCriadas = new List<Ficha>();
            int contagem = 1;
            int qtdZeros = 5;

            while (contagem < quantidadeFichasPorEvento)
            {
                string codigo = contagem.ToString().PadLeft((qtdZeros - contagem.ToString().Length), '0');
                Ficha ficha = new Ficha { Codigo = codigo, Id_evento = id_evento, Saldo = 0 };
                fichasDoEvento.Add(ficha);
                contagem++;
            }

            fichasCriadas = _fichaRepository.Criar(fichasDoEvento.ToList()).ToList();

            return _mapper.Map<IEnumerable<FichaViewModel>>(fichasCriadas);
        }

        public FichaViewModel Criar(FichaViewModel FichaViewModel)
        {
            var model = _mapper.Map<Ficha>(FichaViewModel);
            return _mapper.Map<FichaViewModel>(_fichaRepository.Criar(model));
        }

        public IEnumerable<FichaViewModel> Criar(ICollection<FichaViewModel> fichasViewModel)
        {
            var modelList = _mapper.Map<ICollection<Ficha>>(fichasViewModel.ToList());
            return _mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.Criar(modelList));
        }

        public FichaViewModel Deletar(Guid id)
        {
            return _mapper.Map<FichaViewModel>(_fichaRepository.Deletar(id));
        }

        public IEnumerable<FichaViewModel> EfetuaPagamentoFichas(ICollection<FichaViewModel> fichas, Guid id_pagamento, double totalVenda)
        {
            foreach (var ficha in fichas)
            {
                if (totalVenda > 0)
                {
                    if (ficha.Saldo >= totalVenda)
                    {
                        ficha.Saldo = ficha.Saldo - totalVenda;
                        totalVenda = 0;
                        this.Atualizar(ficha, id_pagamento);
                    }
                    else
                    {
                        totalVenda = totalVenda - ficha.Saldo;
                        ficha.Saldo = 0;
                        this.Atualizar(ficha, id_pagamento);
                    }
                }
            }

            return fichas.ToList();
        }

        public IEnumerable<FichaViewModel> Estorno(Guid id_pagamento)
        {
            var pagamento = _pagamentoRepository.TrazerPorId(id_pagamento);
            var pagamento_fichas = pagamento.Pagamento_Fichas.Where(p => p.Valor.HasValue);
            foreach (var pagamento_ficha in pagamento_fichas)
            {
                pagamento_ficha.Ficha.Saldo = pagamento_ficha.Ficha.Saldo + pagamento_ficha.Valor.Value;
                var ficha = _mapper.Map<FichaViewModel>(pagamento_ficha.Ficha);
                this.Atualizar(ficha, id_pagamento, true);
            }

            return _mapper.Map<IEnumerable<FichaViewModel>>(pagamento_fichas.Select(pf => pf.Ficha).ToList());
        }

        public FichaViewModel Estorno(Guid id_ficha, double valor)
        {
            var fichaViewModel = _mapper.Map<FichaViewModel>(this.TrazerPorId(id_ficha));
            fichaViewModel.Saldo = fichaViewModel.Saldo + valor;
            return this.Atualizar(fichaViewModel);
        }

        public FichaViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<FichaViewModel>(_fichaRepository.TrazerAtivoPorId(id));
        }

        public FichaViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<FichaViewModel>(_fichaRepository.TrazerDeletadoPorId(id));
        }

        public FichaViewModel TrazerPorCodigo(string codigo)
        {
            return _mapper.Map<FichaViewModel>(_fichaRepository.Pesquisar(f => f.Codigo == codigo && f.Deletado == false).FirstOrDefault());
        }

        public FichaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<FichaViewModel>(_fichaRepository.TrazerPorId(id));
        }

        public IEnumerable<FichaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodos().ToList());
        }

        public IEnumerable<FichaViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<FichaViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<FichaViewModel>>(_fichaRepository.TrazerTodosDeletados().ToList());
        }
    }
}
