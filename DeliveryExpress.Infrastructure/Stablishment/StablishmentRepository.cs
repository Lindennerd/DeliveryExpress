using DeliveryExpress.Domain.StablishmentAggregator;
using DeliveryExpress.Infrastructure.DeliveryRequest;

namespace DeliveryExpress.Infrastructure.Stablishment
{
    public class StablishmentRepository : GenericRepository<Domain.StablishmentAggregator.Stablishment>, IStablishmentRepository
    {
        public StablishmentRepository(DeliveryExpressContext context) : base(context)
        { }
    }
}