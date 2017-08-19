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
    public class FichaAppService : IFichaAppService
    {
        private readonly IFichaRepository _fichaRepository;
        private readonly IMapper _mapper;
        public FichaAppService(IFichaRepository fichaRepository, IMapper mapper)
        {
            _fichaRepository = fichaRepository;
            _mapper = mapper;
        }

        public FichaViewModel Atualizar(FichaViewModel FichaViewModel)
        {
            var model = _mapper.Map<Ficha>(FichaViewModel);
            var modelAtualizado = _mapper.Map(FichaViewModel, model);
            return _mapper.Map<FichaViewModel>(_fichaRepository.Atualizar(modelAtualizado));
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

        public FichaViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<FichaViewModel>(_fichaRepository.TrazerAtivoPorId(id));
        }

        public FichaViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<FichaViewModel>(_fichaRepository.TrazerDeletadoPorId(id));
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
