using FluentValidation;

namespace DeliveryExpress.Domain.Common.AddressValueObject
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            _ = RuleFor(x => x.Street).NotEmpty();
            _ = RuleFor(x => x.City).NotEmpty();
            _ = RuleFor(x => x.State).NotEmpty();
            _ = RuleFor(x => x.ZipCode).NotEmpty();
            _ = RuleFor(x => x.Number).NotEmpty().GreaterThan(0);
            _ = RuleFor(x => x.Neighborhood).NotEmpty();
        }
    }
}