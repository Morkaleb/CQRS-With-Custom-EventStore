using Microsoft.AspNetCore.Mvc;
using CQRSWITHES.Infra;
using CQRSWITHES.src.domain;
using CQRSWITHES.src.commands;
using System;

namespace CQRSWITHES.Controllers
{

    public class ExampleController : Controller
    {
        // POST api/values
        [HttpPost]
        [Route("api/[controller]/new")]
        public void Post([FromBody] ExampleCommand value)
        {
            value.Id = Guid.NewGuid().ToString();
            Aggregate exampleDomain = new ExampleAggregate();
            CommandHandler.ActivateCommand(value, exampleDomain);
        }
    }
    
}
;