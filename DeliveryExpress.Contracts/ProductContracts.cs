using DeliveryExpress.Contracts.Common;

namespace DeliveryExpress.Contracts
{
    public static class ProductRequests
    {
        public record CreateProduct(
            string Name,
            string Description,
            decimal Price,
            int StablishmentId
        );
        public record UpdateProduct(
            int ProductId,
            CreateProduct Product
        );
        public record DeleteProduct(
            int ProductId
        );
        public record FilterProduct(
            string? Name,
            string? Description,
            decimal? Price,
            int? StablishmentId
        ) : FilterRequest;
    }

    public static class ProductResponses
    {
        public record Product(
            int ProductId,
            string Name,
            string Description,
            decimal Price,
            int StablishmentId
        );
        public record ProductList(
            int ProductId,
            string Name,
            string Description,
            decimal Price,
            int StablishmentId
        );
        public record ProductDetail(
            int ProductId,
            string Name,
            string Description,
            decimal Price,
            int StablishmentId,
            StablishmentResponses.Stablishment Stablishment
        );
    }
}