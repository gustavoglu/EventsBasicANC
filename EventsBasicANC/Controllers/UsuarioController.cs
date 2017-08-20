using EventsBasicANC.Models;
using EventsBasicANC.Services;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
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
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signManager;
        private readonly IContaAppService _contaAppService;

        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signManager, UsuarioAppService usuarioAppService, IContaAppService contaAppService)
        {
            _userManager = userManager;
            _signManager = signManager;
            _usuarioAppService = usuarioAppService;
            _contaAppService = contaAppService;
        }

        public async Task<IActionResult> Registro([FromBody]UsuarioRegistroViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var usuario = new Usuario { UserName = viewModel.Email, Email = viewModel.Email };
            var result = await _userManager.CreateAsync(usuario, viewModel.Senha);

            if (!result.Succeeded) return BadRequest();

            ContaViewModel conta = new ContaViewModel { Id = Guid.Parse(usuario.Id), };
            var contaCriada = _contaAppService.Criar(conta);

            if (contaCriada == null) return BadRequest();



            return Response(viewModel);

        }
    }
}
