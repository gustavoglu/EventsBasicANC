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
    public class Conta_FuncionarioAppService : IConta_FuncionarioAppService
    {
        private readonly IConta_FuncionarioRepository _conta_funcionarioRepository;
        private readonly IMapper _mapper;

        public Conta_FuncionarioAppService(IConta_FuncionarioRepository conta_funcionarioRepository, IMapper mapper)
        {
            _conta_funcionarioRepository = conta_funcionarioRepository;
            _mapper = mapper;
        }

        public Conta_FuncionarioViewModel Atualizar(Conta_FuncionarioViewModel conta_FuncionarioViewModel)
        {
            var model = _conta_funcionarioRepository.TrazerPorId(conta_FuncionarioViewModel.Id);
            var modelAtualizado = _mapper.Map(conta_FuncionarioViewModel,model);
            return _mapper.Map<Conta_FuncionarioViewModel> (_conta_funcionarioRepository.Atualizar(modelAtualizado));
        }

        public Conta_FuncionarioViewModel Criar(Conta_FuncionarioViewModel conta_FuncionarioViewModel)
        {
            var model = _mapper.Map<Conta_Funcionario>(conta_FuncionarioViewModel);
            return _mapper.Map<Conta_FuncionarioViewModel>(_conta_funcionarioRepository.Criar(model));
        }

        public IEnumerable<Conta_FuncionarioViewModel> Criar(ICollection<Conta_FuncionarioViewModel> conta_FuncionarioViewModel)
        {
            var modelList = _mapper.Map<ICollection<Conta_Funcionario>>(conta_FuncionarioViewModel.ToList());
            return _mapper.Map <IEnumerable<Conta_FuncionarioViewModel>>(_conta_funcionarioRepository.Criar(modelList));
        }

        public Conta_FuncionarioViewModel Deletar(Guid id)
        {
            return _mapper.Map<Conta_FuncionarioViewModel>(_conta_funcionarioRepository.Deletar(id));
        }

        public Conta_FuncionarioViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<Conta_FuncionarioViewModel>(_conta_funcionarioRepository.TrazerAtivoPorId(id));
        }

        public Conta_FuncionarioViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<Conta_FuncionarioViewModel>(_conta_funcionarioRepository.TrazerDeletadoPorId(id));
        }

        public Conta_FuncionarioViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<Conta_FuncionarioViewModel>(_conta_funcionarioRepository.TrazerPorId(id));
        }

        public IEnumerable<Conta_FuncionarioViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<Conta_FuncionarioViewModel>>(_conta_funcionarioRepository.TrazerTodos().ToList());
        }

        public IEnumerable<Conta_FuncionarioViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<Conta_FuncionarioViewModel>>(_conta_funcionarioRepository.TrazerTodosAtivos().ToList());
        }

        public IEnumerable<Conta_FuncionarioViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<Conta_FuncionarioViewModel>>(_conta_funcionarioRepository.TrazerTodosDeletados().ToList());
        }
    }
}
