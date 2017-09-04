using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using EventsBasicANC.Services;

namespace EventsBasicANC.Controllers
{
    [Produces("application/json")]
    //[Route("api/[controller]/[action]")]
    public class ContasController : BaseController
    {
        IContaAppService _contaAppService;
        UsuarioAppService _usuarioAppService;

        public ContasController(IContaAppService contaAppService, UsuarioAppService usuarioAppService)
        {
            _contaAppService = contaAppService;
            _usuarioAppService = usuarioAppService;
        }

        // GET: api/Contas
        [HttpGet]
        [Route("api/Contas")]
        public IEnumerable<ContaViewModel> Get()
        {
            return _contaAppService.TrazerTodosAtivos();
        }

        [Route("api/Funcionarios")]
        [HttpGet]
        public IEnumerable<ContaViewModel> Funcionarios(Guid id_conta)
        {
            return _contaAppService.TrazerFuncionariosAtivos(id_conta);
        }


        [HttpGet]
        [Route("api/Lojas")]
        public IEnumerable<ContaViewModel> Lojas([FromBody]Guid id_loja, Guid id_organizador)
        {
            return _contaAppService.TrazerLojasAtivasPorOrganizador(id_loja, id_organizador);
        }

        [HttpDelete]
        [Route("api/Funcionarios/{id_funcionario:Guid}")]
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
        [Route("api/Lojas/{id_loja:Guid}")]
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

        // GET: api/Contas/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Contas
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contas/5
        [HttpPut]
        [Route("api/Funcionarios")]
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
        [Route("api/Lojas")]
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
