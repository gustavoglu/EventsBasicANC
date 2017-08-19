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
        private readonly IMapper _mapper;
        public MovimentacaoAppService(IMovimentacaoRepository movimentacaoRepository, IMapper mapper)
        {
            _movimentacaoRepository = movimentacaoRepository;
            _mapper = mapper;
        }

        public MovimentacaoViewModel Atualizar(MovimentacaoViewModel MovimentacaoViewModel)
        {
            var model = _mapper.Map<Movimentacao>(MovimentacaoViewModel);
            var modelAtualizado = _mapper.Map(MovimentacaoViewModel, model);
            return _mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.Atualizar(modelAtualizado));
        }

        public MovimentacaoViewModel Criar(MovimentacaoViewModel MovimentacaoViewModel)
        {
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

        public IEnumerable<MovimentacaoViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.TrazerTodosDeletados().ToList());
        }
    }
}
