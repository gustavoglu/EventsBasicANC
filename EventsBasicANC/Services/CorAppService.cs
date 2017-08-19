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
    public class CorAppService : ICorAppService
    {
        private readonly ICorRepository _CorRepository;
        private readonly IMapper _mapper;
        public CorAppService(ICorRepository contaRepository, IMapper mapper)
        {
            _CorRepository = contaRepository;
            _mapper = mapper;
        }

        public CorViewModel Atualizar(CorViewModel CorViewModel)
        {
            var model = _mapper.Map<Cor>(CorViewModel);
            var modelAtualizado = _mapper.Map(CorViewModel, model);
            return _mapper.Map<CorViewModel>(_CorRepository.Atualizar(modelAtualizado));
        }

        public CorViewModel Criar(CorViewModel CorViewModel)
        {
            var model = _mapper.Map<Cor>(CorViewModel);
            return _mapper.Map<CorViewModel>(_CorRepository.Criar(model));
        }

        public IEnumerable<CorViewModel> Criar(ICollection<CorViewModel> contasViewModel)
        {
            var modelList = _mapper.Map<ICollection<Cor>>(contasViewModel.ToList());
            return _mapper.Map<IEnumerable<CorViewModel>>(_CorRepository.Criar(modelList));
        }

        public CorViewModel Deletar(Guid id)
        {
            return _mapper.Map<CorViewModel>(_CorRepository.Deletar(id));
        }

        public CorViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<CorViewModel>(_CorRepository.TrazerAtivoPorId(id));
        }

        public CorViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<CorViewModel>(_CorRepository.TrazerDeletadoPorId(id));
        }

        public CorViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<CorViewModel>(_CorRepository.TrazerPorId(id));
        }

        public IEnumerable<CorViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<CorViewModel>>(_CorRepository.TrazerTodos().ToList());
        }

        public IEnumerable<CorViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<CorViewModel>>(_CorRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<CorViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<CorViewModel>>(_CorRepository.TrazerTodosDeletados().ToList());
        }
    }
}
