using DeliveryExpress.Domain.SeedWork;
using FluentValidation;

namespace DeliveryExpress.Domain.StablishmentAggregator
{
    public class Contact : Entity
    {
        private readonly ContactValidator validator = new();

        private int _stablishmentId;

        public string Phone { get; } = null!;
        public string? Email { get; }
        public string Name { get; } = null!;
        public Stablishment Stablishment { get; } = null!;

        protected Contact()
        {
            Stablishment = null!;
        }

        public Contact(string name, string phone, string? email, int stablishmentId)
        {
            validator.ValidateAndThrow(this);

            Name = name;
            Phone = phone;
            Email = email;
            _stablishmentId = stablishmentId;
        }
        public void SetStablishmentId(int stablishmentId)
        {
            _stablishmentId = stablishmentId;
        }
    }

    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            _ = RuleFor(c => c.Name).NotEmpty();
            _ = RuleFor(c => c.Phone).NotEmpty();
            _ = RuleFor(c => c.Email).EmailAddress();
            _ = RuleFor(c => c.Stablishment).NotNull();
        }
    }
}