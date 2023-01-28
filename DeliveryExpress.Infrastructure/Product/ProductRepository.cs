using DeliveryExpress.Domain.ProductAggregator;
using DeliveryExpress.Domain.SeedWork;
using DeliveryExpress.Infrastructure.DeliveryRequest;

namespace DeliveryExpress.Infrastructure.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly DeliveryExpressContext _context = null!;

        public IUnitOfWork UnitOfWork => _context;

        public ProductRepository(DeliveryExpressContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Domain.ProductAggregator.Product Add(Domain.ProductAggregator.Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.ProductAggregator.Product> GetByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.ProductAggregator.Product product)
        {
            throw new NotImplementedException();
        }
    }
}