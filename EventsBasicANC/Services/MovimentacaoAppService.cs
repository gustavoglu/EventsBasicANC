using AutoMapper;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsBasicANC.Services
{
    public class MovimentacaoAppService : IMovimentacaoAppService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IFichaAppService _fichaAppService;
        private readonly IMapper _mapper;
        public MovimentacaoAppService(IMovimentacaoRepository movimentacaoRepository, IFichaAppService fichaAppService, IMapper mapper)
        {
            _movimentacaoRepository = movimentacaoRepository;
            _fichaAppService = fichaAppService;
            _mapper = mapper;
        }

        public MovimentacaoViewModel Atualizar(MovimentacaoViewModel MovimentacaoViewModel)
        {
            var model = _movimentacaoRepository.TrazerPorId(MovimentacaoViewModel.Id);
            var modelAtualizado = _mapper.Map(MovimentacaoViewModel, model);
            return _mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.Atualizar(modelAtualizado));
        }

        public MovimentacaoViewModel Criar(MovimentacaoViewModel MovimentacaoViewModel)
        {
            var ficha = _fichaAppService.TrazerPorId(MovimentacaoViewModel.Id_ficha);

            var model = _mapper.Map<Movimentacao>(MovimentacaoViewModel);
            return _mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.Criar(model));
        }

        public IEnumerable<MovimentacaoViewModel> Criar(ICollection<MovimentacaoViewModel> movimentacoesViewModel)
        {
            var modelList = _mapper.Map<ICollection<Movimentacao>>(movimentacoesViewModel.ToList());
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.Criar(modelList));
        }

        public MovimentacaoViewModel Deletar(Guid id)
        {
            return _mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.Deletar(id));
        }

        public MovimentacaoViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.TrazerAtivoPorId(id));
        }

        public MovimentacaoViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.TrazerDeletadoPorId(id));
        }

        public MovimentacaoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.TrazerPorId(id));
        }

        public IEnumerable<MovimentacaoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.TrazerTodos().ToList());
        }

        public IEnumerable<MovimentacaoViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<MovimentacaoViewModel> TrazerTodosAtivosPorEvento(Guid id_evento)
        {
            var fichasDoEvento = _fichaAppService.TrazerPorEvento(id_evento);
            if (!fichasDoEvento.Any()) return new List<MovimentacaoViewModel>();

            var movimentacoesFichas = _movimentacaoRepository.TrazerTodosAtivos();
            var movimentacoes = from ficha in fichasDoEvento
                                join movimentacao in movimentacoesFichas on ficha.Id equals movimentacao.Id_ficha
                                select movimentacao;

            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(movimentacoes.ToList());
        }

        public IEnumerable<MovimentacaoViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.TrazerTodosDeletados().ToList());
        }

        public IEnumerable<MovimentacaoViewModel> TrazerTodosDeletadosPorEvento(Guid id_evento)
        {
            var fichasDoEvento = _fichaAppService.TrazerPorEvento(id_evento);
            if (!fichasDoEvento.Any()) return new List<MovimentacaoViewModel>();

            var movimentacoesFichas = _movimentacaoRepository.TrazerTodosDeletados();
            var movimentacoes = from ficha in fichasDoEvento
                                join movimentacao in movimentacoesFichas on ficha.Id equals movimentacao.Id_ficha
                                select movimentacao;

            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(movimentacoes.ToList());
        }

        public IEnumerable<MovimentacaoViewModel> TrazerTodosPorEvento(Guid id_evento)
        {
            var fichasDoEvento = _fichaAppService.TrazerPorEvento(id_evento);
            if (!fichasDoEvento.Any()) return new List<MovimentacaoViewModel>();

            var movimentacoesFichas = _movimentacaoRepository.TrazerTodos();
            var movimentacoes = from ficha in fichasDoEvento
                                join movimentacao in movimentacoesFichas on ficha.Id equals movimentacao.Id_ficha
                                select movimentacao;

            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(movimentacoes.ToList());
        }
    }
}
