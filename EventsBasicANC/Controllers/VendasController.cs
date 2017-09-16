using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventsBasicANC.ViewModels;
using EventsBasicANC.Services.Interfaces;

namespace EventsBasicANC.Controllers
{
    [Produces("application/json")]
    [Route("api/Vendas")]
    public class VendasController : BaseController
    {
        private readonly IVendaAppService _vendaAppService;
        private readonly IFichaAppService _fichaAppService;

        public VendasController(IVendaAppService vendaAppService, IFichaAppService fichaAppService)
        {
            _vendaAppService = vendaAppService;
            _fichaAppService = fichaAppService;
        }

        [HttpGet]
        public IEnumerable<VendaViewModel> Get()
        {
            return _vendaAppService.TrazerTodosAtivos();
        }

        [HttpGet("{id:Guid}")]
        public VendaViewModel Get(Guid id)
        {
            return _vendaAppService.TrazerPorId(id);
        }

        [Route("Total/Loja/{id_loja:Guid}/Evento/{id_evento:Guid}")]
        [HttpGet]
        public double TotalVendasPorLoja(Guid id_loja,Guid id_evento)
        {
            return _vendaAppService.ToTalVendasEventoPorLoja(id_loja, id_evento);
        }

        [HttpPost]
        public IActionResult Post([FromBody]VendaViewModel vendaViewModel)
        {
            if (vendaViewModel == null) return BadRequest("Venda  nula");
            if (!vendaViewModel.Venda_Produtos.Any()) return BadRequest("Uma venda precisa ter produtos (venda_produtos)");
            if (vendaViewModel.Pagamento == null) return BadRequest("Uma venda precisa ter o Pagamento (pagamento)");
            if (!vendaViewModel.Pagamento.Pagamento_Fichas.Any()) return BadRequest("O Pagamento precisa ter fichas");

            double total = vendaViewModel.Total.Value;

            bool existSaldo = vendaViewModel.Pagamento.Pagamento_Fichas.ToList().Sum(pf => pf.Ficha.Saldo) >= total;
            if (!existSaldo) return BadRequest("A Soma da(s) Ficha(s) informadas é menor que o Total da Venda (Sem saldo Suficiente)");

            var vendaCriada = _vendaAppService.Criar(vendaViewModel);
            return Ok();

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
