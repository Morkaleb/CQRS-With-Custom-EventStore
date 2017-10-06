using Microsoft.AspNetCore.Mvc;
using CQRSWithES.Infra;
using CQRSWithES.src.domain;
using CQRSWithES.src.commands;

namespace CQRSWithES.Controllers
{

    public class ExampleController : Controller
    {
        // POST api/values
        [HttpPost]
        [Route("api/[controller]/new")]
        public void Post([FromBody] ExampleCommand value)
        {
            Aggregate exampleDomain = new ExampleAggregate();
            CommandHandler.ActivateCommand(value, exampleDomain);
        }
    }
    
}
;