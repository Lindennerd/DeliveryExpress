using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.StablishmentAggregator
{
    public class Contact : Entity
    {
        public string Phone { get; } = null!;
        public string? Email { get; }
        public string Name { get; } = null!;

        public Contact(string name, string phone, string? email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}