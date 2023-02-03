using DeliveryExpress.Domain.DeliveryRequestAggregator;

namespace DeliveryExpress.Infrastructure.DeliveryRequest
{
    public class DeliveryRequestRepository : GenericRepository<Domain.DeliveryRequestAggregator.DeliveryRequest>, IDeliveryRequestRepository
    {
        public DeliveryRequestRepository(DeliveryExpressContext context) : base(context)
        { }
    }
}