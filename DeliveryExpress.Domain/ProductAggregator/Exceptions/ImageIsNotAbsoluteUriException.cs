namespace DeliveryExpress.Domain.ProductAggregator.Exceptions
{
    public class ImageIsNotAbsoluteUriException : Exception
    {
        public ImageIsNotAbsoluteUriException() : base("Image must be an absolute URI") { }

        public ImageIsNotAbsoluteUriException(string? message) : base(message)
        {
        }

        public ImageIsNotAbsoluteUriException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}