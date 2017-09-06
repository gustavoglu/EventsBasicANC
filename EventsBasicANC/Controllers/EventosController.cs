using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using System;
using Microsoft.AspNetCore.Authorization;

namespace EventsBasicANC.Controllers
{
    [Produces("application/json")]
    [Route("api/Evento")]
    public class EventosController : BaseController
    {

        IEventoAppService _eventoAppService;

        
        public EventosController(IEventoAppService eventoAppService)
        {
            _eventoAppService = eventoAppService;
        }

        // GET: api/Evento
        [HttpGet]
        public IEnumerable<EventoViewModel> Get()
        {
            return _eventoAppService.TrazerTodosAtivos();
        }

        // GET: api/Evento/5
        [HttpGet("{id}", Name = "Get")]
        public EventoViewModel Get(Guid id)
        {
            return _eventoAppService.TrazerPorId(id);
        }

        // POST: api/Evento
        [HttpPost("{qtdFichas:int}")]
        public IActionResult Post([FromBody]EventoViewModel eventoViewModel,int qtdFichas = 0)
        {
            if (!ModelState.IsValid) return BadRequest("");

            return Response(_eventoAppService.Criar(eventoViewModel,qtdFichas));
        }
        [HttpPost]
        public IActionResult Post([FromBody]EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest("");

            return Response(_eventoAppService.Criar(eventoViewModel, 0));
        }

        // PUT: api/Evento/5
        [HttpPut]
        public IActionResult Put([FromBody]EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Response(_eventoAppService.Atualizar(eventoViewModel));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            return Response(_eventoAppService.Deletar(id));
        }
    }
}
