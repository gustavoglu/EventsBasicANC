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
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        public EnderecoAppService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public EnderecoViewModel Atualizar(EnderecoViewModel EnderecoViewModel)
        {
            var model = _mapper.Map<Endereco>(EnderecoViewModel);
            var modelAtualizado = _mapper.Map(EnderecoViewModel, model);
            return _mapper.Map<EnderecoViewModel>(_enderecoRepository.Atualizar(modelAtualizado));
        }

        public EnderecoViewModel Criar(EnderecoViewModel EnderecoViewModel)
        {
            var model = _mapper.Map<Endereco>(EnderecoViewModel);
            return _mapper.Map<EnderecoViewModel>(_enderecoRepository.Criar(model));
        }

        public IEnumerable<EnderecoViewModel> Criar(ICollection<EnderecoViewModel> contasViewModel)
        {
            var modelList = _mapper.Map<ICollection<Endereco>>(contasViewModel.ToList());
            return _mapper.Map<IEnumerable<EnderecoViewModel>>(_enderecoRepository.Criar(modelList));
        }

        public EnderecoViewModel Deletar(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(_enderecoRepository.Deletar(id));
        }

        public EnderecoViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(_enderecoRepository.TrazerAtivoPorId(id));
        }

        public EnderecoViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(_enderecoRepository.TrazerDeletadoPorId(id));
        }

        public EnderecoViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(_enderecoRepository.TrazerPorId(id));
        }

        public IEnumerable<EnderecoViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<EnderecoViewModel>>(_enderecoRepository.TrazerTodos().ToList());
        }

        public IEnumerable<EnderecoViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<EnderecoViewModel>>(_enderecoRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<EnderecoViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<EnderecoViewModel>>(_enderecoRepository.TrazerTodosDeletados().ToList());
        }
    }
}
