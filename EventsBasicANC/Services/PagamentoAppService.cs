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
    public class PagamentoAppService : IPagamentoAppService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;
        public PagamentoAppService(IPagamentoRepository pagamentoRepository, IMapper mapper)
        {
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
        }

        public PagamentoViewModel Atualizar(PagamentoViewModel PagamentoViewModel)
        {
            var model = _mapper.Map<Pagamento>(PagamentoViewModel);
            var modelAtualizado = _mapper.Map(PagamentoViewModel, model);
            return _mapper.Map<PagamentoViewModel>(_pagamentoRepository.Atualizar(modelAtualizado));
        }

        public PagamentoViewModel Criar(PagamentoViewModel PagamentoViewModel)
        {
            var model = _mapper.Map<Pagamento>(PagamentoViewModel);
            return _mapper.Map<PagamentoViewModel>(_pagamentoRepository.Criar(model));
        }

        public IEnumerable<PagamentoViewModel> Criar(ICollection<PagamentoViewModel> pagamentosViewModel)
        {
            var modelList = _mapper.Map<ICollection<Pagamento>>(pagamentosViewModel.ToList());
            return _mapper.Map<IEnumerable<PagamentoViewModel>>(_pagamentoRepository.Criar(modelList));
        }

        public PagamentoViewModel Deletar(Guid id)
        {
            return _mapper.Map<PagamentoViewModel>(_pagamentoRepository.Deletar(id));
        }

        public PagamentoViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<PagamentoViewModel>(_pagamentoRepository.TrazerAtivoPorId(id));
        }

        public PagamentoViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<PagamentoViewModel>(_pagamentoRepository.TrazerDeletadoPorId(id));
        }

        public PagamentoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<PagamentoViewModel>(_pagamentoRepository.TrazerPorId(id));
        }

        public IEnumerable<PagamentoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<PagamentoViewModel>>(_pagamentoRepository.TrazerTodos().ToList());
        }

        public IEnumerable<PagamentoViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<PagamentoViewModel>>(_pagamentoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<PagamentoViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<PagamentoViewModel>>(_pagamentoRepository.TrazerTodosDeletados().ToList());
        }
    }
}
