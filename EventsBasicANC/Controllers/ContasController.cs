using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using EventsBasicANC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EventsBasicANC.Models;
using System.Linq;

namespace EventsBasicANC.Controllers
{
    [Produces("application/json")]
    public class ContasController : BaseController
    {
        IContaAppService _contaAppService;
        UsuarioAppService _usuarioAppService;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signManager;

        public ContasController(IContaAppService contaAppService, UsuarioAppService usuarioAppService, UserManager<Usuario> userManager, SignInManager<Usuario> signManager)
        {
            _contaAppService = contaAppService;
            _usuarioAppService = usuarioAppService;
            _userManager = userManager;
            _signManager = signManager;
        }

        // GET: api/Contas
        [HttpGet]
        [Route("api/Contas")]
        public IEnumerable<ContaViewModel> Get()
        {
            return _contaAppService.TrazerTodosAtivos();
        }

        [Route("api/Contas/Funcionarios")]
        [HttpGet]
        public IEnumerable<ContaViewModel> Funcionarios(Guid id_conta)
        {
            return _contaAppService.TrazerFuncionariosAtivos(id_conta);
        }

        [HttpGet]
        [Route("api/Contas/Lojas")]
        public IEnumerable<ContaViewModel> Lojas([FromBody]Guid id_loja, Guid id_organizador)
        {
            return _contaAppService.TrazerLojasAtivasPorOrganizador(id_loja, id_organizador);
        }

        [HttpDelete]
        [Route("api/Contas/Funcionarios/{id_funcionario:Guid}")]
        public async Task<IActionResult> DeletarFuncionario(Guid id_funcionario)
        {
            var tipoConta = _contaAppService.TrazerTipoDaConta(id_funcionario);
            if (!tipoConta.HasValue || tipoConta.Value != Domain.Models.Enums.ContaTipo.Funcionario) return BadRequest("A conta precisa ser de um Funcionário.");
            var usuarioResult = await _usuarioAppService.Deletar(id_funcionario.ToString());
            if (usuarioResult == null) BadRequest("Ocorreu algum erro ao deletar o Funcionario");
            var result =  _contaAppService.Deletar(id_funcionario);
            if (result == null) BadRequest("Ocorreu algum erro ao deletar o Funcionario");
            return Response(result);
        }

        [HttpDelete]
        [Route("api/Contas/Lojas/{id_loja:Guid}")]
        public async Task<IActionResult> DeletarLoja(Guid id_loja)
        {
            var tipoConta = _contaAppService.TrazerTipoDaConta(id_loja);
            if (!tipoConta.HasValue || tipoConta.Value != Domain.Models.Enums.ContaTipo.Loja) return BadRequest("A conta precisa ser de uma Loja.");
            var usuarioResult = await _usuarioAppService.Deletar(id_loja.ToString());
            if (usuarioResult == null) BadRequest("Ocorreu algum erro ao deletar o Loja");
            var result =  _contaAppService.Deletar(id_loja);
            if (result == null) BadRequest("Ocorreu algum erro ao deletar a Loja");
            return Response(result);
        }

        [HttpPut]
        [Route("api/Contas/Funcionarios")]
        public async Task<IActionResult> AtualizaFuncionario([FromBody]AtualizaFuncionarioViewModel atualizaFuncionarioViewModel)
        {
            var tipoConta = _contaAppService.TrazerTipoDaConta(atualizaFuncionarioViewModel.Id);
            if (tipoConta != Domain.Models.Enums.ContaTipo.Funcionario) return BadRequest("A conta informada não é um Funcionário");
            var usuarioResult = await _usuarioAppService.AtualizaUserName(atualizaFuncionarioViewModel.Id.ToString(),atualizaFuncionarioViewModel.Login);
            if (usuarioResult == null) BadRequest("Algo deu errado ao Atualizar o Funcionario");
            var funcionarioAtualizado = _contaAppService.AtualizarFuncionario(atualizaFuncionarioViewModel);
            if (funcionarioAtualizado == null) return BadRequest("Algo deu errado ao Atualizar o Funcionario");
            return Response(funcionarioAtualizado);
        }

        [HttpPut]
        [Route("api/Contas/Lojas")]
        public async Task<IActionResult> AtualizaLoja([FromBody]AtualizarLojaViewModel atualizarLojaViewModel)
        {
            var tipoConta = _contaAppService.TrazerTipoDaConta(atualizarLojaViewModel.Id);
            if (tipoConta != Domain.Models.Enums.ContaTipo.Loja) return BadRequest("A conta informada não é uma Loja");
            var usuarioResult = await _usuarioAppService.AtualizaUserName(atualizarLojaViewModel.Id.ToString(), atualizarLojaViewModel.Login);
            if (usuarioResult == null) BadRequest("Algo deu errado ao Atualizar a Loja");
            var lojaAtualizada = _contaAppService.AtualizarLoja(atualizarLojaViewModel);
            if (lojaAtualizada == null) return BadRequest("Algo deu errado ao Atualizar a Loja");
            return Response(lojaAtualizada);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Contas/Registro")]
        public async Task<IActionResult> Registro([FromBody]UsuarioRegistroViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var usuario = new Usuario { UserName = viewModel.Email, Email = viewModel.Email };
            var result = await _userManager.CreateAsync(usuario, viewModel.Senha);

            if (!result.Succeeded)
            {
                AdicionaErrosIdentity(result);
                return BadRequest(ModelState.Values.Select(c => c.Errors));
            }

            ContaViewModel conta = new ContaViewModel { Tipo = viewModel.ContaTipo, Id = Guid.Parse(usuario.Id), Endereco = new EnderecoViewModel { Id = Guid.Parse(usuario.Id) }, Contato = new ContatoViewModel { Id = Guid.Parse(usuario.Id) } };
            var contaCriada = _contaAppService.Criar(conta);

            if (contaCriada == null)
            {
                await _userManager.DeleteAsync(await _userManager.FindByIdAsync(usuario.Id));
                return BadRequest("Erro ao criar Conta para o Usuario");
            }

            Usuario usuarioCriado = await _userManager.FindByIdAsync(usuario.Id);
            if (conta.Tipo == Domain.Models.Enums.ContaTipo.Loja) await _userManager.AddClaimsAsync(usuarioCriado, _usuarioAppService.ClaimsLoja());
            if (conta.Tipo == Domain.Models.Enums.ContaTipo.Organizador) await _userManager.AddClaimsAsync(usuarioCriado, _usuarioAppService.ClaimsOrganizador());

            return Response($"Usuario { usuario.UserName } Criado", true);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Contas/NovaSenha")]
        public async Task<IActionResult> NovaSenha([FromBody]NovaSenhaViewModel novaSenhaViewModel)
        {
            var resultUsuario = await _usuarioAppService.AlterarSenha(novaSenhaViewModel.Id_usuario.ToString(), novaSenhaViewModel.NovaSenha);
            if (resultUsuario == null) return BadRequest("Não foi possivel alterar a Senha");
            return Response(resultUsuario);
        }

        [AllowAnonymous]
        [Route("api/Contas/Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UsuarioLoginViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.Select(e => e.Errors));

            var result = await _signManager.PasswordSignInAsync(viewModel.Email, viewModel.Senha, false, true);

            if (!result.Succeeded) return BadRequest(ModelState.Values.Select(e => e.Errors));

            var retorno = _usuarioAppService.ObterTokenUsuario(viewModel);

            return Response(retorno);
        }

        [HttpPost]
        [Route("api/Contas/Lojas")]
        public async Task<IActionResult> Loja([FromBody]NovaLojaViewModel novaLojaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(novaLojaViewModel);

            var usuario = await _usuarioAppService.CriarLojaPorOrganizador(novaLojaViewModel);

            if (usuario == null) return BadRequest("Não foi possivel criar a Loja");

            return Response(usuario);
        }

        [HttpPost]
        [Route("api/Contas/Funcionarios")]
        public async Task<IActionResult> Funcionario([FromBody]NovoFuncionarioViewModel novoFuncionarioViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(novoFuncionarioViewModel);

            var usuarioFunc = await _usuarioAppService.CriarFuncionario(novoFuncionarioViewModel);

            if (usuarioFunc == null) return BadRequest("Não foi possivel criar a Loja");

            return Response(usuarioFunc);
        }

    }
}
