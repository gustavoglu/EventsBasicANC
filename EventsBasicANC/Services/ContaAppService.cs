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
    public class ContaAppService : IContaAppService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;
        public ContaAppService(IContaRepository contaRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _mapper = mapper;
        }

        public ContaViewModel Atualizar(ContaViewModel contaViewModel)
        {
            var model = _mapper.Map<Conta>(contaViewModel);
            var modelAtualizado = _mapper.Map(contaViewModel, model);
            return _mapper.Map<ContaViewModel>(_contaRepository.Atualizar(modelAtualizado));
        }

        public ContaViewModel Criar(ContaViewModel contaViewModel)
        {
            var model = _mapper.Map<Conta>(contaViewModel);
            return _mapper.Map<ContaViewModel>(_contaRepository.Criar(model));
        }

        public IEnumerable<ContaViewModel> Criar(ICollection<ContaViewModel> contasViewModel)
        {
            var modelList = _mapper.Map<ICollection<Conta>>(contasViewModel.ToList());
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.Criar(modelList));
        }

        public ContaViewModel Deletar(Guid id)
        {
            return _mapper.Map<ContaViewModel>(_contaRepository.Deletar(id));
        }

        public ContaViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<ContaViewModel>(_contaRepository.TrazerAtivoPorId(id));
        }

        public ContaViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<ContaViewModel>(_contaRepository.TrazerDeletadoPorId(id));
        }

        public ContaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<ContaViewModel>(_contaRepository.TrazerPorId(id));
        }

        public IEnumerable<ContaViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.TrazerTodos().ToList());
        }

        public IEnumerable<ContaViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<ContaViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.TrazerTodosDeletados().ToList());
        }
    }
}
