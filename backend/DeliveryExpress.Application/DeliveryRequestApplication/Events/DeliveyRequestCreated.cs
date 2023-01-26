using MediatR;
using Microsoft.Extensions.Logging;

namespace DeliveryExpress.Application.DeliveryRequestApplication.Events
{
    public class DeliveryRequestCreated : INotification
    {
        public int Id { get; set; }
    }

    public class DeliveryRequestCreatedHandler : INotificationHandler<DeliveryRequestCreated>
    {
        private readonly ILogger<DeliveryRequestCreatedHandler> logger;

        public DeliveryRequestCreatedHandler(ILogger<DeliveryRequestCreatedHandler> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Handle(DeliveryRequestCreated notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Delivery request created");
            return Task.CompletedTask;
        }
    }
}