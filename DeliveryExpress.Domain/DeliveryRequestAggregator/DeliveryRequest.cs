using DeliveryExpress.Domain.ClientAggregator;
using DeliveryExpress.Domain.Common.AddressValueObject;
using DeliveryExpress.Domain.DeliveryRequestAggregator.Events;
using DeliveryExpress.Domain.SeedWork;
using FluentValidation;

namespace DeliveryExpress.Domain.DeliveryRequestAggregator
{
    public class DeliveryRequest : Entity, IAggregateRoot
    {
        private readonly DeliveryRequestValidator validator = new();

        private readonly int _clientId;

        public Client Client { get; } = default!;
        public Address Address { get; private set; } = null!;
        public DateTime RequestDate { get; } = DateTime.Now;
        public DateTime? DeliveryDate { get; private set; }
        public DeliveryRequestStatus Status { get; private set; } = DeliveryRequestStatus.Pending;

        public StablishmentAggregator.Stablishment Stablishment { get; } = null!;

        public List<DeliveryItem> Items { get; } = new(Array.Empty<DeliveryItem>());

        private DeliveryRequest()
        {
            Client = null!;
        }

        public DeliveryRequest(int clientId, Address address) : this()
        {
            _clientId = clientId;
            Address = address;

            validator.ValidateAndThrow(this);

            AddDomainEvent(new DeliveryRequestCreated { Id = Id });
        }

        public void AddItem(DeliveryItem item)
        {
            if (Status.Id > 1)
            {
                throw new InvalidOperationException("Cannot add items to a delivery request that is not pending");
            }

            if (item.Product is not null)
            {
                throw new InvalidOperationException("Cannot add an item with an invalid product id");
            }

            if (item.Quantity <= 0)
            {
                throw new InvalidOperationException("Cannot add an item with an invalid quantity");
            }

            Items.Add(item);
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
            _ = RuleFor(x => x.Client).NotNull();
            _ = RuleFor(x => x.Status)
                .Must(x => x.Id is > 0 and < 7)
                .WithMessage("Invalid status. It must be either Pending (1), Accepted (2), Rejected (3), InProgress (4), Delivered (5) or Canceled (6)");
        }
    }
}