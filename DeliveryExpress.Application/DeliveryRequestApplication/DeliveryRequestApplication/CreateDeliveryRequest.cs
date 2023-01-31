using DeliveryExpress.Domain.Common.AddressValueObject;
using DeliveryExpress.Domain.DeliveryRequestAggregator;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeliveryExpress.Application.DeliveryRequestApplication.DeliveryRequestApplication
{
    public record DeliveryItemRequest(int ProductId, int Quantity);

    public class CreateDeliveryRequest : IRequest<CreateDeliveryRequestResponse>
    {
        public int ClientId { get; set; }
        public int ContactId { get; set; }
        public IEnumerable<DeliveryItemRequest> Items { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }

    public record ClientResponse(string Name, string Phone, int Id);
    public record StablishmentResponse(string Name, string Phone, int Id);
    public record ProductResponse(int Id, string Name, string Description, decimal Price, string Image);
    public record DeliveryItemResponse(ProductResponse Product, int Quantity);

    public class CreateDeliveryRequestResponse
    {
        public int Id { get; set; }
        public ClientResponse Client { get; set; } = default!;
        public StablishmentResponse Stablishment { get; set; } = default!;
        public IEnumerable<DeliveryItemResponse> Items { get; set; } = null!;
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

            request.Items.ToList().ForEach(item => deliveryRequest.AddItem(new DeliveryItem(item.ProductId, item.Quantity)));

            DeliveryRequest created = deliveryRequestRepository.Add(deliveryRequest);
            _ = await deliveryRequestRepository.UnitOfWork.SaveEntitiesAsync<DeliveryRequest>(cancellationToken);

            return new CreateDeliveryRequestResponse
            {
                Id = created.Id,
                Client = new ClientResponse(created.Client.Name, created.Client.Phone, created.Client.Id),
                Stablishment = new StablishmentResponse(created.Stablishment.Name, created.Stablishment.Phone, created.Stablishment.Id),
                Items = created.Items.Select(x => new DeliveryItemResponse(new ProductResponse(x
                    .Product
                    .Id, x.Product.Name, x.Product.Description, x.Product.Price, x
                    .Product
                    .Image?
                    .AbsoluteUri ?? string.Empty), x.Quantity)),
                Address = created.Address
            };
        }
    }
}