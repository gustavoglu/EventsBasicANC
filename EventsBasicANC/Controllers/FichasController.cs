using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;

namespace EventsBasicANC.Controllers
{
    [Produces("application/json")]
    [Route("api/Fichas")]
    public class FichasController : BaseController
    {
        IFichaAppService _fichaAppService;

        public FichasController(IFichaAppService fichaAppService)
        {
            _fichaAppService = fichaAppService;
        }

        [HttpGet]
        public IEnumerable<FichaViewModel> Get()
        {
            return _fichaAppService.TrazerTodosAtivos();
        }

        [HttpGet("{id:Guid}")]
        public FichaViewModel Get(Guid id)
        {
            return _fichaAppService.TrazerPorId(id);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]FichaViewModel fichaViewModel)
        {
            if(!ModelState.IsValid) return BadRequest("Verifique as informações enviadas");
            if (fichaViewModel == null) return BadRequest("Nenhuma Ficha Informada");
            if (!_fichaAppService.ValidaCodigoDaFicha(fichaViewModel.Codigo)) return BadRequest("Informe um código de ficha válido");
            if (_fichaAppService.CodigoFichaExist(fichaViewModel.Codigo, fichaViewModel.Id_evento)) return BadRequest("Este código de ficha ja esta sendo utilizado por outro cliente");
            var fichaCriada = _fichaAppService.Criar(fichaViewModel);
            return Response(fichaCriada);
        }
        
        [HttpPut]
        public IActionResult Put(FichaViewModel fichaViewModel)
        {
            if (fichaViewModel == null) return BadRequest("Nenhuma Ficha Informada");
            var exist = _fichaAppService.TrazerPorId(fichaViewModel.Id);
            if (exist == null) return BadRequest("Esta Ficha não existe");
            var fichaAtualizada = _fichaAppService.Atualizar(fichaViewModel);
            return Response(fichaAtualizada);
        }
        
        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var exist = _fichaAppService.TrazerPorId(id);
            if (exist == null) return BadRequest("Ficha não encontrada");
            var fichaDeletada = _fichaAppService.Deletar(id);
            return Response(fichaDeletada);
        }
    }
}
