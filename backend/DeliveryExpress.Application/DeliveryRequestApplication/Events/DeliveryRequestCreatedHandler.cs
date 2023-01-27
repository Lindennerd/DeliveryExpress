using DeliveryExpress.Domain.DeliveryRequestAggregator.Events;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace DeliveryExpress.Application.DeliveryRequestApplication.Events
{
    public class DeliveryRequestCreatedHandler : INotificationHandler<DeliveryRequestCreated>
    {
        private readonly ILogger<DeliveryRequestCreatedHandler> logger;
        private readonly IHubContext<DeliveryExpressHub> hub;

        public DeliveryRequestCreatedHandler(ILogger<DeliveryRequestCreatedHandler> logger, IHubContext<DeliveryExpressHub> hub)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.hub = hub;
        }

        public Task Handle(DeliveryRequestCreated notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Delivery request created");
            _ = hub.Clients.All.SendAsync("DeliveryRequestCreated", notification.Id, cancellationToken);
            return Task.CompletedTask;
        }
    }
}