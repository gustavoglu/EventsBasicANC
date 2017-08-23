using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using EventsBasicANC.ViewModels.Validations.Produto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsBasicANC.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ProdutosController : BaseController
    {
        IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        public IQueryable<ProdutoViewModel> Get()
        {
            return _produtoAppService.TrazerTodosAtivos().AsQueryable();
        }

        [HttpPost]
        public IActionResult Post(ProdutoViewModel produto)
        {
            var validations = new CriarProdutoValidation().Validate(produto);
            if (!validations.IsValid) return BadRequest(validations.Errors.Select(e => new { erro = e.ErrorMessage }));
            var produtoViewModel = _produtoAppService.Criar(produto);
            return Response(produtoViewModel);
        }

        [HttpPut]
        public IActionResult Put(ProdutoViewModel produto)
        {
            var validations = new AtualizarProdutoValidation().Validate(produto);
            if (!validations.IsValid) return BadRequest(validations.Errors.Select(e => new { erro = e.ErrorMessage }));
            var produtoViewModel = _produtoAppService.Atualizar(produto);
            return Response(produtoViewModel);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var validations = new DeletarProdutoValidation().Validate(new ProdutoViewModel() { Id = id });
            if (!validations.IsValid) return BadRequest (validations.Errors.Select(e => e.ErrorMessage));
            var exist = _produtoAppService.TrazerPorId(id);
            var produtoDeletado = _produtoAppService.Deletar(id);
            return Response(produtoDeletado);
        }
    }
}
