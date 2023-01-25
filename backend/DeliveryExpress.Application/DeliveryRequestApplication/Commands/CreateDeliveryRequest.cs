using DeliveryExpress.Contracts.Common;
using DeliveryExpress.Contracts.CreateDeliveryRequest;
using DeliveryExpress.Domain.DeliveryRequestAggregator;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DeliveryExpress.Application.DeliveryRequestApplication.Commands
{
    public class CreateDeliveryRequest : IRequest<CreateDeliveryRequestResponse>
    {
        public int ClientId { get; set; }
        public int ContactId { get; set; }
        public IEnumerable<DeliveryItems> Items { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }

    public class CreateDeliveryRequestHandler : IRequestHandler<CreateDeliveryRequest, CreateDeliveryRequestResponse>
    {
        private readonly ILogger<CreateDeliveryRequestHandler> logger;
        private readonly IDeliveryRequestRepository deliveryRequestRepository;

        public CreateDeliveryRequestHandler(
            ILogger<CreateDeliveryRequestHandler> logger,
            IDeliveryRequestRepository deliveryRequestRepository)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.deliveryRequestRepository = deliveryRequestRepository;
        }

        public async Task<CreateDeliveryRequestResponse> Handle(CreateDeliveryRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating delivery request");
            DeliveryRequest deliveryRequest = new(
                request.ClientId,
                request.ContactId,
                new Domain.Common.AddressValueObject.Address(
                    request.Address.Street,
                    request.Address.City,
                    request.Address.ZipCode,
                    request.Address.Complement,
                    request.Address.Neighborhood
                ));
            DeliveryRequest created = deliveryRequestRepository.Add(deliveryRequest);
            _ = await deliveryRequestRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return new() { Id = created.Id };
        }
    }
}