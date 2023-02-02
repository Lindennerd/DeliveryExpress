using DeliveryExpress.Application.DeliveryRequestApplication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryExpress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class DeliveryRequestController : Controller
    {
        private readonly ILogger<DeliveryRequestController> logger;
        private readonly IMediator mediator;

        public DeliveryRequestController(ILogger<DeliveryRequestController> logger, IMediator mediator)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateDeliveryRequestResponse), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public async Task<ActionResult<CreateDeliveryRequestResponse>> CreateDeliveryRequest([FromBody] CreateDeliveryRequest request)
        {
            try
            {
                logger.LogInformation("Creating delivery request");
                CreateDeliveryRequestResponse response = await mediator.Send(new CreateDeliveryRequest
                {
                    Address = request.Address,
                    Items = request.Items,
                    ClientId = request.ClientId,
                    ContactId = 1 //TODO! request.StablishmentId
                });

                return Ok(response);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error creating delivery request");
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task GetDeliveryRequest(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task GetDeliveryRequests()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task UpdateDeliveryRequest(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task DeleteDeliveryRequest(int id)
        {
            throw new NotImplementedException();
        }
    }
}