
using Microsoft.AspNetCore.Mvc;

namespace DeliveryExpress.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
