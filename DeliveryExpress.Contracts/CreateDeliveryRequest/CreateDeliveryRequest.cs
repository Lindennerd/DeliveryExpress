using DeliveryExpress.Contracts.Common;

namespace DeliveryExpress.Contracts.CreateDeliveryRequest
{
    public class CreateDeliveryRequest
    {
        public int ClientId { get; set; }

        public Address Address { get; set; } = null!;
        public IEnumerable<DeliveryItems> Items { get; set; } = null!;
    }

    public class DeliveryItems
    {
        public int Product { get; set; }
        public int Quantity { get; set; }
    }
}