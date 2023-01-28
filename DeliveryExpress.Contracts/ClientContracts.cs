using DeliveryExpress.Contracts.Common;

namespace DeliveryExpress.Contracts
{
    public static class ClientRequests
    {
        public record CreateClient(
            string Name,
            string Phone,
            string Email
        );
        public record UpdateClient(
            int ClientId,
            CreateClient Client
        );
        public record DeleteClient(
            int ClientId
        );
        public record FilterClient(
            string? Name,
            string? Phone,
            string? Email
        ) : FilterRequest;
    }

    public static class ClientResponses
    {
        public record Client(
            int ClientId,
            string Name,
            string Phone,
            string Email
        );
        public record ClientList(
            int ClientId,
            string Name,
            string Phone,
            string Email
        );
        public record ClientDetail(
            int ClientId,
            string Name,
            string Phone,
            string Email
        );
    }
}