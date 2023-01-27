using DeliveryExpress.Domain.DeliveryRequestAggregator;
using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Infrastructure.DeliveryRequest
{
    public class DeliveryRequestRepository : IDeliveryRequestRepository
    {
        private readonly DeliveryExpressContext _context = null!;

        public IUnitOfWork UnitOfWork => _context;

        public DeliveryRequestRepository(DeliveryExpressContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Domain.DeliveryRequestAggregator.DeliveryRequest Add(Domain.DeliveryRequestAggregator.DeliveryRequest deliveryRequest)
        {
            return _context.DeliveryRequests.Add(deliveryRequest).Entity;
        }

        public async Task<Domain.DeliveryRequestAggregator.DeliveryRequest> GetByDeliveryRequestIdAsync(int deliveryRequestId)
        {
            return await _context.DeliveryRequests.FindAsync(deliveryRequestId);
        }

        public void Update(Domain.DeliveryRequestAggregator.DeliveryRequest deliveryRequest)
        {
            _context.DeliveryRequests.Update(deliveryRequest);
        }
    }
}