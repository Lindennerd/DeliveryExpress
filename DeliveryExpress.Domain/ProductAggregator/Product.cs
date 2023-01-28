using DeliveryExpress.Domain.ProductAggregator.Exceptions;
using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.ProductAggregator
{
    public class Product : Entity, IAggregateRoot
    {
        public string Description { get; } = null!;

        public decimal Price { get; }
        public Uri? Image { get; }
        public string Name { get; } = null!;

        protected Product()
        {
        }

        public Product(string name, string description, decimal price, Uri? image)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }
            if (price <= 0)
            {
                throw new PriceIsNegativeOrZeroException();
            }
            if (image?.IsAbsoluteUri == false)
            {
                throw new ImageIsNotAbsoluteUriException();
            }

            Description = description;
            Name = name;
            Image = image;
            Price = price;
        }
    }
}