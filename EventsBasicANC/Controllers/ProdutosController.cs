using EventsBasicANC.Domain.Models.Enums;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EventsBasicANC.Controllers
{
    [AllowAnonymous]
    public class ProdutosController : BaseController
    {
        IProdutoAppService _produtoAppService;
        IContaAppService _contaAppService;

        public ProdutosController(IProdutoAppService produtoAppService, IContaAppService contaAppService)
        {
            _produtoAppService = produtoAppService;
            _contaAppService = contaAppService;
        }

        [Route("api/Produtos")]
        [HttpGet]
        public IQueryable<ProdutoViewModel> Get()
        {
            return _produtoAppService.TrazerTodosAtivos().AsQueryable();
        }

        [Route("api/Produtos/Loja/{id_loja:Guid}")]
        [HttpGet]
        public IQueryable<ProdutoViewModel> Loja(Guid id_loja)
        {
            return _produtoAppService.TrazerAtivoPorLoja(id_loja).AsQueryable();
        }

        [HttpGet]
        [Route("api/Produtos/{id_produto:Guid}")]
        public ProdutoViewModel Get(Guid id_produto)
        {
            return _produtoAppService.TrazerPorId(id_produto);
        }

        [HttpPost]
        [Route("api/Produtos/")]
        public IActionResult Post([FromBody]ProdutoViewModel produto)
        {
            var contaTipo = _contaAppService.TrazerTipoDaConta(produto.Id_loja);
            if (contaTipo == ContaTipo.Funcionario || contaTipo == ContaTipo.Funcionario) return BadRequest("O id_conta precisa ser de uma loja");
            if (produto == null) return BadRequest("Nenhum Produto Informado");

            var produtoViewModel = _produtoAppService.Criar(produto);
            return Response(produtoViewModel);
        }

        [HttpPut]
        [Route("api/Produtos/")]
        public IActionResult Put([FromBody]ProdutoViewModel produto)
        {
            var exist = _produtoAppService.TrazerPorId(produto.Id.Value);
            if (exist == null) return BadRequest("Este produto não existe");
            var produtoViewModel = _produtoAppService.Atualizar(produto);
            return Response(produtoViewModel);
        }


        [HttpDelete]
        [Route("api/Produtos/{id_produto:Guid}")]
        public IActionResult Delete(Guid id_produto)
        {
            var exist = _produtoAppService.TrazerPorId(id_produto);
            if (exist == null) return BadRequest("Este produto não existe");

            var produtoDeletado = _produtoAppService.Deletar(id_produto);
            return Response(produtoDeletado);
        }
    }
}
