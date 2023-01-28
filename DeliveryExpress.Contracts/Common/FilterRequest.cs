namespace DeliveryExpress.Contracts.Common
{
    public abstract class FilterRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}