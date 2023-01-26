using DeliveryExpress.Domain.DeliveryRequestAggregator;
using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Infrastructure.DeliveryRequest
{
    public class DeliveryRequestRepository : IDeliveryRequestRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Domain.DeliveryRequestAggregator.DeliveryRequest Add(Domain.DeliveryRequestAggregator.DeliveryRequest deliveryRequest)
        {
            return deliveryRequest;
        }

        public Task<Domain.DeliveryRequestAggregator.DeliveryRequest> GetByDeliveryRequestIdAsync(int deliveryRequestId)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.DeliveryRequestAggregator.DeliveryRequest deliveryRequest)
        {
            throw new NotImplementedException();
        }
    }
}