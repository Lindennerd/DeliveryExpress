using Microsoft.AspNetCore.Mvc;

namespace DeliveryExpress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController
    {
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Hello World";
        }

        // [HttpGet]
        // public ActionResult<string> Get([FromQuery] FilterClientsRequest filterRequest)
        // {
        //     return filterRequest.Name;
        // }

        [HttpPost]
        public ActionResult<string> Post()
        {
            return "Hello World";
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(int id)
        {
            return "Hello World";
        }
    }
}