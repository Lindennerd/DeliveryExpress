namespace DeliveryExpress.Contracts.Common
{
    public record FilterRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}