using DeliveryExpress.Domain.SeedWork;
using DeliveryExpress.Domain.StablishmentAggregator;
using DeliveryExpress.Infrastructure.DeliveryRequest;

namespace DeliveryExpress.Infrastructure.Stablishment
{
    public class StablishmentRepository : IStablishmentRepository
    {
        private readonly DeliveryExpressContext _context = null!;
        public IUnitOfWork UnitOfWork => _context;

        public StablishmentRepository(DeliveryExpressContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Domain.StablishmentAggregator.Stablishment Add(Domain.StablishmentAggregator.Stablishment stablishment)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.StablishmentAggregator.Stablishment stablishment)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.StablishmentAggregator.Stablishment> GetByStablishmentIdAsync(int stablishmentId)
        {
            throw new NotImplementedException();
        }
    }
}