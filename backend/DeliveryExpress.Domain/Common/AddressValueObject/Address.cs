using DeliveryExpress.Domain.SeedWork;
using FluentValidation;

namespace DeliveryExpress.Domain.Common.AddressValueObject
{
    public class Address : ValueObject
    {
        public Address(string street, string city, string country, string zipCode, string complement, string neighborhood)
        {
            _validator.ValidateAndThrow(this);

            Street = street;
            City = city;
            Country = country;
            ZipCode = zipCode;
            Complement = complement;
            Neighborhood = neighborhood;
        }

        private readonly AddressValidator _validator = new();

        public string Street { get; } = null!;
        public string City { get; } = null!;
        public string State { get; } = null!;
        public string Country { get; } = null!;
        public string ZipCode { get; } = null!;
        public int Number { get; }
        public string Complement { get; } = null!;
        public string Neighborhood { get; } = null!;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return State;
            yield return Country;
            yield return ZipCode;
            yield return Number;
            yield return Complement;
            yield return Neighborhood;
        }
    }
}