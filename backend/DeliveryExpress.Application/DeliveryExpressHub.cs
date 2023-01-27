using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace DeliveryExpress.Application
{
    public class DeliveryExpressHub : Hub
    {
        private readonly ILogger<DeliveryExpressHub> logger;

        public DeliveryExpressHub(ILogger<DeliveryExpressHub> logger)
        {
            this.logger = logger;
        }

        public override Task OnConnectedAsync()
        {
            logger.LogInformation("Connected");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            logger.LogInformation("Disconnected");
            return base.OnDisconnectedAsync(exception);
        }
    }
}