using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using EventsBasicANC.Domain.Models.Enums;

namespace EventsBasicANC.Controllers
{
    [Produces("application/json")]

    public class MovimentacoesController : BaseController
    {
        private readonly IMovimentacaoAppService _movimentacaoAppService;
        private readonly IFichaAppService _fichaAppService;

        public MovimentacoesController(IMovimentacaoAppService movimentacaoAppService, IFichaAppService fichaAppService)
        {
            _movimentacaoAppService = movimentacaoAppService;
            _fichaAppService = fichaAppService;
        }
        // GET: api/Movimentacoes
        [HttpGet]
        public IEnumerable<MovimentacaoViewModel> Get()
        {
            return _movimentacaoAppService.TrazerTodosAtivos();
        }

        [HttpGet]
        [Route("api/Movimentacoes/Evento/{id_evento:Guid}")]
        public IEnumerable<MovimentacaoViewModel> TrazerPorEvento(Guid id_evento)
        {
            return _movimentacaoAppService.TrazerTodosAtivosPorEvento(id_evento);
        }

        [Route("api/Movimentacoes/{id:Guid}")]
        [HttpGet]
        public MovimentacaoViewModel Get(Guid id)
        {
            return _movimentacaoAppService.TrazerAtivoPorId(id);
        }

        [HttpPost]
        [Route("api/Movimentacoes/")]
        public IActionResult Post([FromBody]MovimentacaoViewModel movimentacaoViewModel)
        {
            if (movimentacaoViewModel.Id_ficha == null) return BadRequest("id_ficha chegou nulo");
            var ficha = _fichaAppService.TrazerPorId(movimentacaoViewModel.Id_ficha);
            if (ficha == null) return Response("Esta ficha não existe", false);

            ficha.Saldo = movimentacaoViewModel.MovimentacaoTipo == MovimentacaoTipo.Entrada ||
                          movimentacaoViewModel.MovimentacaoTipo == MovimentacaoTipo.Estorno ? ficha.Saldo + movimentacaoViewModel.Valor :
                          ficha.Saldo - movimentacaoViewModel.Valor;

            bool estorno = movimentacaoViewModel.MovimentacaoTipo == MovimentacaoTipo.Estorno;

            var fichaAtualizada = _fichaAppService.Atualizar(ficha, null, estorno, movimentacaoViewModel.Observacao);

            return Response(fichaAtualizada, true);
        }

    }
}
