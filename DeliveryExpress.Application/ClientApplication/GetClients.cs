using DeliveryExpress.Application.Common;
using DeliveryExpress.Domain.ClientAggregator;
using MediatR;

namespace DeliveryExpress.Application.ClientApplication
{
    public class GetClientsRequest : IRequest<GetClientsResponse>
    {
        public FilterSpecification Filter { get; set; } = null!;
    }

    public class GetClientsResponse
    {
        public int Total { get; set; }
        public Client[] Clients { get; set; } = null!;
    }

    public class GetClientsRequestHandler : IRequestHandler<GetClientsRequest, GetClientsResponse>
    {
        private readonly IClientRepository clientRepository;

        public GetClientsRequestHandler(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Client> clients = await clientRepository.GetAsync(request.Filter, cancellationToken);

            return new GetClientsResponse
            {
                Total = clients.Count(),
                Clients = clients.ToArray()
            };
        }
    }
}