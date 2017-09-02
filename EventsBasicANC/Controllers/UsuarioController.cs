using EventsBasicANC.Models;
using EventsBasicANC.Services;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventsBasicANC.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsuarioController : BaseController
    {
        private readonly UsuarioAppService _usuarioAppService;
        private readonly IFichaAppService _fichaAppService;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signManager;
        private readonly IContaAppService _contaAppService;

        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signManager, UsuarioAppService usuarioAppService, IContaAppService contaAppService, IFichaAppService fichaAppService)
        {
            _userManager = userManager;
            _signManager = signManager;
            _usuarioAppService = usuarioAppService;
            _contaAppService = contaAppService;
            _fichaAppService = fichaAppService;
        }

        public string Teste()
        {
            return "TESTE";
        }

        [AllowAnonymous]
        [HttpPost]
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
        public async Task<IActionResult> NovaSenha([FromBody]NovaSenhaViewModel novaSenhaViewModel)
        {
            var resultUsuario = await _usuarioAppService.AlterarSenha(novaSenhaViewModel.Id_usuario.ToString(), novaSenhaViewModel.NovaSenha);
            if (resultUsuario == null) return BadRequest("Não foi possivel alterar a Senha");
            return Response(resultUsuario);
        }

        [AllowAnonymous]
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
        public async Task<IActionResult> Loja([FromBody]NovaLojaViewModel novaLojaViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(novaLojaViewModel);

            var usuario = await _usuarioAppService.CriarLojaPorOrganizador(novaLojaViewModel);

            if (usuario == null) return BadRequest("Não foi possivel criar a Loja");

            return Response(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Funcionario([FromBody]NovoFuncionarioViewModel novoFuncionarioViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(novoFuncionarioViewModel);

            var usuarioFunc = await _usuarioAppService.CriarFuncionario(novoFuncionarioViewModel);

            if (usuarioFunc == null) return BadRequest("Não foi possivel criar a Loja");

            return Response(usuarioFunc);
        }


    }
}
