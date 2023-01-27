namespace DeliveryExpress.Domain.ProductAggregator.Exceptions
{
    public class PriceIsNegativeOrZeroException : Exception
    {
        public PriceIsNegativeOrZeroException() : base("Price must be greater than 0") { }

        public PriceIsNegativeOrZeroException(string? message) : base(message)
        {
        }

        public PriceIsNegativeOrZeroException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}