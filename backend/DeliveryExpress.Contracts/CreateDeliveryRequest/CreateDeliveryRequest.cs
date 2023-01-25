namespace DeliveryExpress.Contracts.CreateDeliveryRequest
{
    public class CreateDeliveryRequest
    {
        public IEnumerable<DeliveryItems> Items { get; set; } = null!;
    }

    public class DeliveryItems
    {
        public int Product { get; set; }
        public int Quantity { get; set; }
    }
}