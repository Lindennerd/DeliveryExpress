using DeliveryExpress.Domain.SeedWork;
using FluentValidation;

namespace DeliveryExpress.Domain.StablishmentAggregator
{
    public class Contact : Entity
    {
        private readonly ContactValidator validator = new();

        public string Phone { get; } = null!;
        public string? Email { get; }
        public string Name { get; } = null!;

        public Contact(string name, string phone, string? email)
        {
            validator.ValidateAndThrow(this);

            Name = name;
            Phone = phone;
            Email = email;
        }
    }

    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            _ = RuleFor(c => c.Name).NotEmpty();
            _ = RuleFor(c => c.Phone).NotEmpty();
            _ = RuleFor(c => c.Email).EmailAddress();
        }
    }
}