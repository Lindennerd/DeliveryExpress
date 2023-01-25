using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.ProductAggregator
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);
        void Update(Product product);
        Task<Product> GetByProductIdAsync(int productId);
    }
}