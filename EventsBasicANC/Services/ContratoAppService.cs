using EventsBasicANC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EventsBasicANC.ViewModels;
using EventsBasicANC.Data.Repository.Interfaces;
using AutoMapper;
using EventsBasicANC.Models;

namespace EventsBasicANC.Services
{
    public class ContratoAppService : IContratoAppService
    {
        private readonly IContratoRepository _ContratoRepository;
        private readonly IMapper _mapper;

        public ContratoAppService(IContratoRepository contaRepository, IMapper mapper)
        {
            _ContratoRepository = contaRepository;
            _mapper = mapper;
        }

        public ContratoViewModel Atualizar(ContratoViewModel ContratoViewModel)
        {
            var model = _mapper.Map<Contrato>(ContratoViewModel);
            var modelAtualizado = _mapper.Map(ContratoViewModel, model);
            return _mapper.Map<ContratoViewModel>(_ContratoRepository.Atualizar(modelAtualizado));
        }

        public ContratoViewModel Criar(ContratoViewModel ContratoViewModel)
        {
            var model = _mapper.Map<Contrato>(ContratoViewModel);
            return _mapper.Map<ContratoViewModel>(_ContratoRepository.Criar(model));
        }

        public IEnumerable<ContratoViewModel> Criar(ICollection<ContratoViewModel> contasViewModel)
        {
            var modelList = _mapper.Map<ICollection<Contrato>>(contasViewModel.ToList());
            return _mapper.Map<IEnumerable<ContratoViewModel>>(_ContratoRepository.Criar(modelList));
        }

        public ContratoViewModel Deletar(Guid id)
        {
            return _mapper.Map<ContratoViewModel>(_ContratoRepository.Deletar(id));
        }

        public ContratoViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<ContratoViewModel>(_ContratoRepository.TrazerAtivoPorId(id));
        }

        public ContratoViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<ContratoViewModel>(_ContratoRepository.TrazerDeletadoPorId(id));
        }

        public ContratoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<ContratoViewModel>(_ContratoRepository.TrazerPorId(id));
        }

        public IEnumerable<ContratoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<ContratoViewModel>>(_ContratoRepository.TrazerTodos().ToList());
        }

        public IEnumerable<ContratoViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<ContratoViewModel>>(_ContratoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<ContratoViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<ContratoViewModel>>(_ContratoRepository.TrazerTodosDeletados().ToList());
        }
    }
}
