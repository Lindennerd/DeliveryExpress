using DeliveryExpress.Domain.ClientAggregator;
using DeliveryExpress.Domain.SeedWork;
using DeliveryExpress.Infrastructure.DeliveryRequest;

namespace DeliveryExpress.Infrastructure.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly DeliveryExpressContext _context = null!;

        public IUnitOfWork UnitOfWork => _context;

        public ClientRepository(DeliveryExpressContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Domain.ClientAggregator.Client Add(Domain.ClientAggregator.Client client)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.ClientAggregator.Client> AddAsync(Domain.ClientAggregator.Client client)
        {
            UnitOfWork.SaveChangesAsync();
            return null;
        }

        public Task<Domain.ClientAggregator.Client> GetByClientIdAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.ClientAggregator.Client client)
        {
            throw new NotImplementedException();
        }
    }
}