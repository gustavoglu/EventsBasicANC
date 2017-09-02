using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;

namespace EventsBasicANC.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ContasController : Controller
    {
        IContaAppService _contaAppService;

        public ContasController(IContaAppService contaAppService)
        {
            _contaAppService = contaAppService;
        }

        // GET: api/Contas
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public IEnumerable<ContaViewModel> Funcionarios(Guid id_conta)
        {
            return _contaAppService.TrazerFuncionariosAtivos(id_conta);
        }

        [HttpGet]
        public IEnumerable<ContaViewModel> Lojas(Guid id_loja,Guid id_organizador)
        {
            return _contaAppService.TrazerLojasAtivasPorOrganizador(id_loja, id_organizador);
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
