using DeliveryExpress.Contracts.CreateDeliveryRequest;
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

        public DeliveryRequestController(ILogger<DeliveryRequestController> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateDeliveryRequestResponse), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ValidationProblemDetails))]
        public ActionResult<CreateDeliveryRequestResponse> CreateDeliveryRequest([FromBody] CreateDeliveryRequest request)
        {
            try
            {
                logger.LogInformation("Creating delivery request");
                CreateDeliveryRequestResponse response = new()
                {
                    Id = 1
                };
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