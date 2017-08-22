using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsBasicANC.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public ProdutoViewModel Post(ProdutoViewModel produto)
        {
            return _produtoAppService.Criar(produto);
        }

        [HttpPost]
        public IQueryable<ProdutoViewModel> Post(ICollection<ProdutoViewModel> produtos)
        {
            return _produtoAppService.Criar(produtos).AsQueryable();
        }

        [HttpPut]
        public ProdutoViewModel Put(ProdutoViewModel produto)
        {
            var exist = _produtoAppService.TrazerPorId(produto.Id);
            return _produtoAppService.Atualizar(produto);
        }

        [HttpDelete]
        public ProdutoViewModel Delete(Guid id)
        {
            var exist = _produtoAppService.TrazerPorId(id);
            return _produtoAppService.Deletar(id);
        }
    }
}
