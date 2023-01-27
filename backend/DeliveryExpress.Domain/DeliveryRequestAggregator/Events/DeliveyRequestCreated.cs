using MediatR;

namespace DeliveryExpress.Domain.DeliveryRequestAggregator.Events
{
    public class DeliveryRequestCreated : INotification
    {
        public int Id { get; set; }
    }
}