using DeliveryExpress.Domain.Common.AddressValueObject;
using DeliveryExpress.Domain.SeedWork;
using FluentValidation;

namespace DeliveryExpress.Domain.ClientAggregator
{
    public class Client : Entity, IAggregateRoot
    {
        private readonly ClientValidator validator = new();

        public string Name { get; } = null!;
        public string Phone { get; } = null!;
        public string? Email { get; }
        public Address Address { get; } = null!;

        protected Client() { }

        public Client(string name, string phone, string? email, Address address)
        {
            validator.ValidateAndThrow(this);

            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }
    }

    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            _ = RuleFor(x => x.Name).NotEmpty();
            _ = RuleFor(x => x.Phone).NotEmpty().Matches(@"^\d{2}-\d{4}-\d{4}$");
            _ = RuleFor(x => x.Email).EmailAddress();
            _ = RuleFor(x => x.Address).NotNull();
        }
    }
}