using EventsBasicANC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EventsBasicANC.ViewModels;
using EventsBasicANC.Data.Repository.Interfaces;
using AutoMapper;
using EventsBasicANC.Models;
using EventsBasicANC.Domain.Models.Enums;

namespace EventsBasicANC.Services
{
    public class ContaAppService : IContaAppService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IContatoRepository _contatoRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IContratoRepository _contratoRepository;
        private readonly IConta_FuncionarioRepository _conta_FuncionarioRepository;
        private readonly IMapper _mapper;
        public ContaAppService(IContaRepository contaRepository, IContratoRepository contratoRepository, IConta_FuncionarioRepository conta_FuncionarioRepository, IContatoRepository contatoRepository, IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            _contaRepository = contaRepository;
            _contratoRepository = contratoRepository;
            _conta_FuncionarioRepository = conta_FuncionarioRepository;
            _contatoRepository = contatoRepository;
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        public ContaViewModel Atualizar(ContaViewModel contaViewModel)
        {
            var model = _contaRepository.TrazerPorId(contaViewModel.Id);
            var modelAtualizado = _mapper.Map(contaViewModel, model);
            return _mapper.Map<ContaViewModel>(_contaRepository.Atualizar(modelAtualizado));
        }

        public ContaViewModel AtualizarFuncionario(AtualizaFuncionarioViewModel atualizaFuncionarioaViewModel)
        {
            var funcionario = this.TrazerPorId(atualizaFuncionarioaViewModel.Id);
            if (funcionario == null) return null;
            Contato contato = _contatoRepository.TrazerPorId(atualizaFuncionarioaViewModel.Id);
            contato.NomeCompleto = atualizaFuncionarioaViewModel.NomeCompleto;
            var contatoAtualizado = _contatoRepository.Atualizar(contato);
            if (contatoAtualizado == null) return null;
            funcionario.Login = atualizaFuncionarioaViewModel.Login;
            var funcionarioAtualizado = this.Atualizar(funcionario);
            if (funcionarioAtualizado == null) return null;
            return funcionarioAtualizado;
        }

        public ContaViewModel AtualizarLoja(AtualizarLojaViewModel atualizaLojaViewModel)
        {
            var loja = this.TrazerPorId(atualizaLojaViewModel.Id);
            if (loja == null) return null;

            loja.RazaoSocial = atualizaLojaViewModel.RazaoSocial;
            loja.NomeFantasia = atualizaLojaViewModel.NomeFantasia;
            loja.Login = atualizaLojaViewModel.Login;

            Contato contato = _contatoRepository.TrazerPorId(atualizaLojaViewModel.Id);

            contato.NomeCompleto = atualizaLojaViewModel.NomeCompleto;
            contato.Documento = atualizaLojaViewModel.Documento;
            contato.DocumentoTipo = atualizaLojaViewModel.DocumentoTipo ?? DocumentoTipo.CPF;
            contato.Email = atualizaLojaViewModel.Email;
            contato.EmailAdicional = atualizaLojaViewModel.EmailAdicional;
            contato.Telefone = atualizaLojaViewModel.Telefone;
            contato.Telefone2 = atualizaLojaViewModel.Telefone2;

            Contato contatoAtualizado = _contatoRepository.Atualizar(contato);
            if (contatoAtualizado == null) return null;

            Endereco endereco = _enderecoRepository.TrazerPorId(atualizaLojaViewModel.Id);

            endereco.Cidade = atualizaLojaViewModel.Cidade;
            endereco.Estado = atualizaLojaViewModel.Estado;
            endereco.Rua = atualizaLojaViewModel.Rua;
            endereco.Bairro = atualizaLojaViewModel.Bairro;

            Endereco enderecoAtualizado = _enderecoRepository.Atualizar(endereco);
            if (enderecoAtualizado == null) return null;

            var lojaAtualizado = this.Atualizar(loja);
            if (lojaAtualizado == null) return null;
            return lojaAtualizado;
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
            Conta conta = _contaRepository.TrazerPorId(id); ;
            return _mapper.Map<ContaViewModel>(conta);
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
