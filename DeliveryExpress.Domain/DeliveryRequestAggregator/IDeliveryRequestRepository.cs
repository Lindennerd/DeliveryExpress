using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.DeliveryRequestAggregator
{
    public interface IDeliveryRequestRepository : IRepository<DeliveryRequest>
    {
        DeliveryRequest Add(DeliveryRequest deliveryRequest);
        void Update(DeliveryRequest deliveryRequest);
        Task<DeliveryRequest> GetByDeliveryRequestIdAsync(int deliveryRequestId);
    }
}