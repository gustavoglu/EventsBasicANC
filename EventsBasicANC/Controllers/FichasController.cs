using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;

namespace EventsBasicANC.Controllers
{
    [Produces("application/json")]
    public class FichasController : BaseController
    {
        IFichaAppService _fichaAppService;

        public FichasController(IFichaAppService fichaAppService)
        {
            _fichaAppService = fichaAppService;
        }

        [HttpGet]
        [Route("api/Fichas/{id_evento:Guid}")]
        public IEnumerable<FichaViewModel> Get(Guid id_evento)
        {
            return _fichaAppService.TrazerPorEvento(id_evento);
        }

        [HttpGet]
        [Route("api/Fichas/{id_ficha:Guid}/{id_evento:Guid}")]
        public FichaViewModel Get(Guid id_ficha, Guid id_evento)
        {
            return _fichaAppService.TrazerPorId(id_ficha, id_evento);
        }

        [HttpGet("api/Fichas/{codigoFicha}/{id_evento:Guid}")]
        public FichaViewModel Get(string codigoFicha, Guid id_evento)
        {
            return _fichaAppService.TrazerPorCodigo(codigoFicha, id_evento);
        }

    }
}
