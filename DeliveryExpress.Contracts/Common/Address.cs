namespace DeliveryExpress.Contracts.Common
{
    public class Address
    {
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public int Number { get; set; }
        public string Complement { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
    }
}