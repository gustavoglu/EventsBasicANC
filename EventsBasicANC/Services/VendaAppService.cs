﻿using AutoMapper;
using EventsBasicANC.Data.Repository.Interfaces;
using EventsBasicANC.Models;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsBasicANC.Services
{
    public class VendaAppService : IVendaAppService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IPagamentoAppService _pagamentoAppService;
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IFichaAppService _fichaAppService;
        private readonly IMapper _mapper;
        public VendaAppService(IVendaRepository vendaRepository, IMovimentacaoRepository movimentacaoRepository, IFichaAppService fichaAppService, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _movimentacaoRepository = movimentacaoRepository;
            this._fichaAppService = fichaAppService;
            _mapper = mapper;
        }

        public VendaViewModel Atualizar(VendaViewModel VendaViewModel)
        {
            var model = _mapper.Map<Venda>(VendaViewModel);
            var modelAtualizado = _mapper.Map(VendaViewModel, model);
            return _mapper.Map<VendaViewModel>(_vendaRepository.Atualizar(modelAtualizado));
        }

        public VendaViewModel Cancelar(Guid id)
        {
            var venda = _mapper.Map<VendaViewModel>(_vendaRepository.TrazerPorId(id));

            _fichaAppService.Estorno(venda.Id);

            venda.Cancelada = true;

            return this.Atualizar(venda);
        }

        public VendaViewModel Criar(VendaViewModel VendaViewModel)
        {
            var fichas = VendaViewModel.Pagamento.Pagamento_Fichas.Select(pf => pf.Ficha).ToList();
            double totalVenda = VendaViewModel.Total.Value;

            var model = _mapper.Map<Venda>(VendaViewModel);
            var vendaCriada = _mapper.Map<VendaViewModel>(_vendaRepository.Criar(model));

            var fichasAtualizadas = _fichaAppService.EfetuaPagamentoFichas(fichas, VendaViewModel.Pagamento.Id, totalVenda);

      
            return vendaCriada;
        }

        public IEnumerable<VendaViewModel> Criar(ICollection<VendaViewModel> vendasViewModel)
        {
            var modelList = _mapper.Map<ICollection<Venda>>(vendasViewModel.ToList());
            return _mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.Criar(modelList));
        }

        public VendaViewModel Deletar(Guid id)
        {
            return _mapper.Map<VendaViewModel>(_vendaRepository.Deletar(id));
        }

        public double ToTalVendasEventoPorLoja(Guid id_loja, Guid id_evento)
        {
            var vendas = _vendaRepository.PesquisarAtivos(v => v.Id_loja == id_loja && v.Id_Evento == id_evento).ToList();
            if (vendas == null || !vendas.Any()) return 0;
            double totalVendas = vendas.Sum(v => v.Total.Value);
            return totalVendas;
        }

        public VendaViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<VendaViewModel>(_vendaRepository.TrazerAtivoPorId(id));
        }

        public VendaViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<VendaViewModel>(_vendaRepository.TrazerDeletadoPorId(id));
        }

        public VendaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<VendaViewModel>(_vendaRepository.TrazerPorId(id));
        }

        public IEnumerable<VendaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.TrazerTodos().ToList());
        }

        public IEnumerable<VendaViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<VendaViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<VendaViewModel>>(_vendaRepository.TrazerTodosDeletados().ToList());
        }

        public IEnumerable<VendaViewModel> VendasPorEvento(Guid id_evento)
        {
            var vendas = _vendaRepository.PesquisarAtivos(v => v.Id_Evento == id_evento).ToList();
            return _mapper.Map<IEnumerable<VendaViewModel>>(vendas);
        }
    }
}
