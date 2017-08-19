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
    public class ContatoAppService : IContatoAppService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;
        public ContatoAppService(IContatoRepository contaRepository, IMapper mapper)
        {
            _contatoRepository = contaRepository;
            _mapper = mapper;
        }

        public ContatoViewModel Atualizar(ContatoViewModel ContatoViewModel)
        {
            var model = _mapper.Map<Contato>(ContatoViewModel);
            var modelAtualizado = _mapper.Map(ContatoViewModel, model);
            return _mapper.Map<ContatoViewModel>(_contatoRepository.Atualizar(modelAtualizado));
        }

        public ContatoViewModel Criar(ContatoViewModel ContatoViewModel)
        {
            var model = _mapper.Map<Contato>(ContatoViewModel);
            return _mapper.Map<ContatoViewModel>(_contatoRepository.Criar(model));
        }

        public IEnumerable<ContatoViewModel> Criar(ICollection<ContatoViewModel> contasViewModel)
        {
            var modelList = _mapper.Map<ICollection<Contato>>(contasViewModel.ToList());
            return _mapper.Map<IEnumerable<ContatoViewModel>>(_contatoRepository.Criar(modelList));
        }

        public ContatoViewModel Deletar(Guid id)
        {
            return _mapper.Map<ContatoViewModel>(_contatoRepository.Deletar(id));
        }

        public ContatoViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<ContatoViewModel>(_contatoRepository.TrazerAtivoPorId(id));
        }

        public ContatoViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<ContatoViewModel>(_contatoRepository.TrazerDeletadoPorId(id));
        }

        public ContatoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<ContatoViewModel>(_contatoRepository.TrazerPorId(id));
        }

        public IEnumerable<ContatoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(_contatoRepository.TrazerTodos().ToList());
        }

        public IEnumerable<ContatoViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(_contatoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<ContatoViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<ContatoViewModel>>(_contatoRepository.TrazerTodosDeletados().ToList());
        }
    }
}
