using DeliveryExpress.Contracts.Common;
using static DeliveryExpress.Contracts.ProductResponses;

namespace DeliveryExpress.Contracts
{
    public record Contact(
        string Name,
        string Phone,
        string Email
    );

    public static class StablishmentRequests
    {
        public record CreateStablishment(
            string Name,
            Address Address,
            string Phone
        );

        public record UpdateStablishment(
            int StablishmentId,
            CreateStablishment Stablishment
        );

        public record DeleteStablishment(
            int StablishmentId
        );

        public record AddContact(
            int StablishmentId,
            Contact Contact
        );

        public record FilterStablishment(
            string? Name,
            string? Address,
            string? Phone
        ) : FilterRequest;
    }

    public static class StablishmentResponses
    {
        public record Stablishment(
            int StablishmentId,
            string Name,
            Address Address,
            string Phone
        );

        public record StablishmentList(
            int StablishmentId,
            string Name,
            Address Address,
            string Phone
        );

        public record StablishmentDetail(
            int StablishmentId,
            string Name,
            Address Address,
            string Phone,
            List<Contact> Contacts,
            List<Product> Products,
            List<ClientResponses.Client> Clients
        );
    }
}