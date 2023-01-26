using DeliveryExpress.Domain.Common.AddressValueObject;
using DeliveryExpress.Domain.SeedWork;
using FluentValidation;

namespace DeliveryExpress.Domain.DeliveryRequestAggregator
{
    public class DeliveryRequest : Entity, IAggregateRoot
    {
        private readonly DeliveryRequestValidator validator = new();

        public int Client { get; } = default!;
        public int Contact { get; private set; } = default!;
        public Address Address { get; private set; } = null!;
        public DateTime RequestDate { get; } = DateTime.Now;
        public DateTime? DeliveryDate { get; private set; }
        public DeliveryRequestStatus Status { get; private set; } = DeliveryRequestStatus.Pending;

        public DeliveryRequest(int clientId, int contactId, Address address)
        {
            Client = clientId;
            Contact = contactId;
            Address = address;

            validator.ValidateAndThrow(this);
        }

        public void UpdateStatus(DeliveryRequestStatus status)
        {
            if (status == DeliveryRequestStatus.Delivered)
            {
                DeliveryDate = DateTime.Now;
            }

            if (status.Id > Status.Id)
            {
                throw new InvalidOperationException("Cannot update status to a previous state");
            }

            Status = status;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public void UpdateContact(int contactId)
        {
            Contact = contactId;
        }

        public void UpdateDeliveryDate(DateTime deliveryDate)
        {
            DeliveryDate = deliveryDate;
        }
    }

    public class DeliveryRequestValidator : AbstractValidator<DeliveryRequest>
    {
        public DeliveryRequestValidator()
        {
            _ = RuleFor(x => x.Address).NotNull();
            _ = RuleFor(x => x.Client).GreaterThan(0);
            _ = RuleFor(x => x.Contact).GreaterThan(0);
            _ = RuleFor(x => x.Status)
                .Must(x => x.Id is > 0 and < 7)
                .WithMessage("Invalid status. It must be either Pending (1), Accepted (2), Rejected (3), InProgress (4), Delivered (5) or Canceled (6)");
        }
    }
}