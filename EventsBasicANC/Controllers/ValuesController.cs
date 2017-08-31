using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EventsBasicANC.Services.Interfaces;
using EventsBasicANC.ViewModels;
using Rhino.Mocks;
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
        public OrganizadorContainerViewModel Get()
        {
            var container = Builder<OrganizadorContainerViewModel>.CreateNew().Build();
            return container;
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
