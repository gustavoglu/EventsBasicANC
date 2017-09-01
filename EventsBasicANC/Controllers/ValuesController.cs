using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using System.ComponentModel;
using FizzWare.NBuilder;

namespace EventsBasicANC.Controllers
{
  
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [AllowAnonymous]
        [HttpGet]
        public string Get()
        {

            return "Ok";
            //var container = Builder<ContainerViewModel>.CreateNew().Build();
            //container.Evento = Builder<EventoContainerViewModel>.CreateNew().Build();
            //container.Lojas = Builder<NovaLojaViewModel>.CreateListOfSize(10).Build();
            //container.Organizador = Builder<OrganizadorContainerViewModel>.CreateNew().Build();

            //foreach (var loja in container.Lojas)
            //{
            //    loja.Endereco = Builder<EnderecoContainerViewModel>.CreateNew().Build();
            //    loja.Contato = Builder<ContatoContainerViewModel>.CreateNew().Build();
            //    loja.Funcionarios = Builder<NovoFuncionarioViewModel>.CreateListOfSize(3).Build();
            //    loja.Produtos = Builder<ProdutoContainerViewModel>.CreateListOfSize(5).Build();
            //}

            //container.Organizador.Funcionarios = Builder<NovoFuncionarioViewModel>.CreateListOfSize(2).Build();
            
            //return container;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
