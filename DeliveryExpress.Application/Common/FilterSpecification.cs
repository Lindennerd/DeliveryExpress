namespace DeliveryExpress.Application.Common
{
    public class FilterSpecification
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? OrderByDirection { get; set; }
        public string? Filter { get; set; }
    }
}