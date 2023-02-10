using DeliveryExpress.Application.ClientApplication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryExpress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> logger;
        private readonly IMediator mediator;

        public ClientController(ILogger<ClientController> logger, IMediator mediator)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mediator = mediator;
        }

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
        public async Task<ActionResult<CreateClientResponse>> Post([FromBody] CreateClientRequest request)
        {
            try
            {
                logger.LogInformation("Creating client");
                return await mediator.Send(request);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error creating client");
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(int id)
        {
            return "Hello World";
        }
    }
}