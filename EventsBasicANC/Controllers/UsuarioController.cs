using EventsBasicANC.Models;
using EventsBasicANC.Services;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EventsBasicANC.Controllers
{
    [Route("api/[controller]")]
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

            ContaViewModel conta = new ContaViewModel { Id = Guid.NewGuid() };
            var contaCriada = _contaAppService.Criar(conta);

            if (!ModelState.IsValid) return BadRequest();

            var usuario = new Usuario { UserName = viewModel.Email, Email = viewModel.Email };
            var result = await _userManager.CreateAsync(usuario, viewModel.Senha);

            if (!result.Succeeded) return BadRequest();

           

            if (contaCriada == null) return BadRequest();

            return Response(viewModel);

        }
    }
}
