using DeliveryExpress.Domain.SeedWork;
using FluentValidation;

namespace DeliveryExpress.Domain.Common.AddressValueObject
{
    public class Address : ValueObject
    {
        public Address(string street, int number, string state, string city, string zipCode, string complement, string neighborhood)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
            Complement = complement;
            Neighborhood = neighborhood;
            Number = number;
            State = state;

            _validator.ValidateAndThrow(this);
        }

        private readonly AddressValidator _validator = new();

        public string Street { get; } = null!;
        public string City { get; } = null!;
        public string State { get; } = null!;
        public string ZipCode { get; } = null!;
        public int Number { get; }
        public string Complement { get; } = null!;
        public string Neighborhood { get; } = null!;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return State;
            yield return ZipCode;
            yield return Number;
            yield return Complement;
            yield return Neighborhood;
        }
    }
}