using DeliveryExpress.Contracts.Common;

namespace DeliveryExpress.Contracts
{
    public record DeliveryItem(
        int ProductId,
        int Quantity
    );

    public static class DeliveryRequestRequests
    {
        public record CreateDeliveryRequest(
            int ClientId,
            int StablishmentId,
            List<DeliveryItem> Items
        );
        public record UpdateDeliveryRequest(
            int DeliveryId,
            CreateDeliveryRequest Delivery
        );
        public record DeleteDeliveryRequest(
            int DeliveryId
        );
        public record FilterDeliveryRequest(
            int? ClientId,
            int? StablishmentId
        ) : FilterRequest;
    }

    public static class DeliveryRequestResponses
    {
        public record DeliveryRequest(
            int DeliveryId,
            int ClientId,
            int StablishmentId,
            List<DeliveryItem> Items
        );
        public record DeliveryRequestList(
            int DeliveryId,
            int ClientId,
            int StablishmentId,
            List<DeliveryItem> Items
        );
        public record DeliveryRequestDetail(
            int DeliveryId,
            int ClientId,
            int StablishmentId,
            List<DeliveryItem> Items,
            ClientResponses.Client Client,
            StablishmentResponses.Stablishment Stablishment,
            ProductResponses.Product Product
        );
    }
}