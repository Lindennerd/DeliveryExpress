using DeliveryExpress.Domain.ProductAggregator;
using DeliveryExpress.Domain.SeedWork;
using DeliveryExpress.Infrastructure.DeliveryRequest;

namespace DeliveryExpress.Infrastructure.Product
{
    public class ProductRepository : GenericRepository<Domain.ProductAggregator.Product>, IProductRepository
    {
        public ProductRepository(DeliveryExpressContext context) : base(context)
        { }
    }
}