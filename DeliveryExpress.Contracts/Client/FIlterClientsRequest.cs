using DeliveryExpress.Contracts.Common;

namespace DeliveryExpress.Contracts.Client
{
    public class FilterClientsRequest : FilterRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }

    public class FilterClientResponse
    {
        public List<Domain.ClientAggregator.Client> Clients { get; set; } = null!;
    }
}