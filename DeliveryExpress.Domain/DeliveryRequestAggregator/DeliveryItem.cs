using DeliveryExpress.Domain.ProductAggregator;
using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.DeliveryRequestAggregator
{
    public class DeliveryItem : Entity
    {
        private readonly int _deliveryRequestId;
        private readonly int _productId;

        public DeliveryRequest DeliveryRequest { get; }
        public Product Product { get; }
        public int Quantity { get; }

        protected DeliveryItem()
        {
        }

        public DeliveryItem(int deliveryRequestId, int productId, int quantity)
        {
            _deliveryRequestId = deliveryRequestId;
            _productId = productId;
            Quantity = quantity;
        }
    }
}