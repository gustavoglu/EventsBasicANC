using EventsBasicANC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EventsBasicANC.ViewModels;
using EventsBasicANC.Data.Repository.Interfaces;
using AutoMapper;
using EventsBasicANC.Models;
using EventsBasicANC.Domain.Models.Enums;
using EventsBasicANC.Data.Repository;

namespace EventsBasicANC.Services
{
    public class ContaAppService : IContaAppService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IContratoRepository _contratoRepository;
        private readonly IConta_FuncionarioRepository _conta_FuncionarioRepository;
        private readonly IMapper _mapper;
        public ContaAppService(IContaRepository contaRepository, IContratoRepository contratoRepository, IConta_FuncionarioRepository conta_FuncionarioRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _contratoRepository = contratoRepository;
            _conta_FuncionarioRepository = conta_FuncionarioRepository;
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

        public IEnumerable<ContaViewModel> TrazerFuncionariosAtivos(Guid id_conta)
        {
            var conta_Funcionarios = _conta_FuncionarioRepository.TrazerPorContaPrincipal(id_conta);
            var contas = conta_Funcionarios.Select(cf => cf.Conta);
            return _mapper.Map<IEnumerable<ContaViewModel>>(contas);
        }

        public IEnumerable<ContaViewModel> TrazerLojasAtivasPorOrganizador(Guid id_loja, Guid id_organizador)
        {
            var contratos = _contratoRepository.Pesquisar(c => c.Id_loja == id_loja && c.Id_organizador == id_organizador);
            var lojas = contratos.Select(c => c.Loja);
            return _mapper.Map<IEnumerable<ContaViewModel>>(lojas);
        }

        public ContaViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<ContaViewModel>(_contaRepository.TrazerPorId(id));
        }

        public ContaTipo? TrazerTipoDaConta(Guid id_conta)
        {
            var contaTipo = _contaRepository.TrazerAtivoPorId(id_conta).Tipo;
            return contaTipo;
        }

        public ContaTipo? TrazerTipoFuncionario(Guid id_conta_funcionario)
        {
            var contaFuncionarioTipo = this.TrazerTipoDaConta(id_conta_funcionario);
            if (contaFuncionarioTipo != ContaTipo.Funcionario) return null;
            var funcionario = this.TrazerPorId(id_conta_funcionario);
            var contas_funcionario = _conta_FuncionarioRepository.TrazerPorFuncionario(id_conta_funcionario);
            if (!contas_funcionario.Any()) return null;
            var conta_funcionario = contas_funcionario.FirstOrDefault();
            var contaPrincipal = _contaRepository.TrazerPorId(conta_funcionario.Id_conta);
            return contaPrincipal.Tipo;
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
