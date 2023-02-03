using DeliveryExpress.Domain.ClientAggregator;
using DeliveryExpress.Infrastructure.DeliveryRequest;

namespace DeliveryExpress.Infrastructure.Client
{
    public class ClientRepository : GenericRepository<Domain.ClientAggregator.Client>, IClientRepository
    {
        public ClientRepository(DeliveryExpressContext context) : base(context)
        { }
    }
}