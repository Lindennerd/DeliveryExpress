using DeliveryExpress.Domain.Common.AddressValueObject;
using DeliveryExpress.Domain.DeliveryRequestAggregator;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeliveryExpress.Application.DeliveryRequestApplication.DeliveryRequestApplication
{
    public class CreateDeliveryRequest : IRequest<CreateDeliveryRequestResponse>
    {
        public int ClientId { get; set; }
        public int ContactId { get; set; }
        public IEnumerable<DeliveryItem> Items { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }

    public class CreateDeliveryRequestResponse
    {
        public int Id { get; set; }
        public Domain.ClientAggregator.Client Client { get; set; } = null!;
        public Domain.StablishmentAggregator.Stablishment Stablishment { get; set; } = null!;
        public IEnumerable<DeliveryItem> Items { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }

    public class CreateDeliveryRequestValidator : AbstractValidator<CreateDeliveryRequest>
    {
        public CreateDeliveryRequestValidator()
        {
            _ = RuleFor(x => x.ClientId).NotEmpty();
            _ = RuleFor(x => x.ContactId).NotEmpty();
            _ = RuleFor(x => x.Items).NotEmpty();
            _ = RuleFor(x => x.Address).NotNull();
        }
    }

    public class CreateDeliveryRequestHandler : IRequestHandler<CreateDeliveryRequest, CreateDeliveryRequestResponse>
    {
        private readonly ILogger<CreateDeliveryRequestHandler> logger;
        private readonly IDeliveryRequestRepository deliveryRequestRepository;

        private readonly CreateDeliveryRequestValidator validator;

        public CreateDeliveryRequestHandler(
            ILogger<CreateDeliveryRequestHandler> logger,
            IDeliveryRequestRepository deliveryRequestRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.deliveryRequestRepository = deliveryRequestRepository;

            validator = new CreateDeliveryRequestValidator();
        }

        public async Task<CreateDeliveryRequestResponse> Handle(CreateDeliveryRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating delivery request");

            validator.ValidateAndThrow(request);

            DeliveryRequest deliveryRequest = new(
                request.ClientId,
                new Address(
                    request.Address.Street,
                    request.Address.Number,
                    request.Address.State,
                    request.Address.City,
                    request.Address.ZipCode,
                    request.Address.Complement,
                    request.Address.Neighborhood
                ));

            request.Items.ToList().ForEach(item => deliveryRequest.AddItem(new DeliveryItem(item.Product.Id, item.Quantity)));

            DeliveryRequest created = deliveryRequestRepository.Add(deliveryRequest);
            _ = await deliveryRequestRepository.UnitOfWork.SaveEntitiesAsync<DeliveryRequest>(cancellationToken);

            return new CreateDeliveryRequestResponse
            {
                Id = created.Id,
                Client = created.Client,
                Stablishment = created.Stablishment,
                Items = created.Items,
                Address = created.Address
            };
        }
    }
}