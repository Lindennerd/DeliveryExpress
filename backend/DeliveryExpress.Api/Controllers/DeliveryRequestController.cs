using DeliveryExpress.Contracts.CreateDeliveryRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CreateDeliveryRequestCommand = DeliveryExpress.Application.DeliveryRequestApplication.Commands.CreateDeliveryRequest;

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

        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateDeliveryRequestResponse), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public async Task<ActionResult<CreateDeliveryRequestResponse>> CreateDeliveryRequest([FromBody] CreateDeliveryRequest request)
        {
            try
            {
                logger.LogInformation("Creating delivery request");
                CreateDeliveryRequestResponse response = await mediator.Send(new CreateDeliveryRequestCommand
                {
                    Items = request.Items,
                    ClientId = request.ClientId,
                    ContactId = 1 //TODO! request.StablishmentId
                });
                return Ok(response);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error creating delivery request");
                return BadRequest();
            }
        }
    }
}