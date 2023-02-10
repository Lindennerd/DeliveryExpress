using DeliveryExpress.Domain.ClientAggregator;
using DeliveryExpress.Domain.Common.AddressValueObject;
using FluentValidation;
using MediatR;

namespace DeliveryExpress.Application.ClientApplication
{
    public class CreateClientRequest : IRequest<CreateClientResponse>
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }

    public class CreateClientResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public Address Address { get; set; } = null!;
    }

    public class CreateClientRequestValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
            _ = RuleFor(x => x.Name).NotEmpty();
            _ = RuleFor(x => x.Email).NotEmpty();
            _ = RuleFor(x => x.Phone).NotEmpty();
            _ = RuleFor(x => x.Address).NotNull();
        }
    }

    public class CreateClientRequestHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
    {
        private readonly IClientRepository clientRepository;

        private readonly CreateClientRequestValidator validator;

        public CreateClientRequestHandler(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;

            validator = new CreateClientRequestValidator();
        }

        public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
        {
            validator.ValidateAndThrow(request);

            Client client = new(request.Name, request.Email, request.Phone, request.Address);

            _ = await clientRepository.AddAsync(client, cancellationToken);

            return new CreateClientResponse
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone,
                Address = client.Address
            };
        }
    }
}