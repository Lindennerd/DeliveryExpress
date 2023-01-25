using System.ComponentModel;
using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.DeliveryRequestAggregator
{
    public class DeliveryRequestStatus : Enumeration
    {
        public static DeliveryRequestStatus Pending = new(1, nameof(Pending).ToLowerInvariant());
        public static DeliveryRequestStatus Accepted = new(2, nameof(Accepted).ToLowerInvariant());
        public static DeliveryRequestStatus Rejected = new(3, nameof(Rejected).ToLowerInvariant());
        public static DeliveryRequestStatus InProgress = new(4, nameof(InProgress).ToLowerInvariant());
        public static DeliveryRequestStatus Delivered = new(5, nameof(Delivered).ToLowerInvariant());
        public static DeliveryRequestStatus Canceled = new(6, nameof(Canceled).ToLowerInvariant());

        public DeliveryRequestStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<DeliveryRequestStatus> List() =>
        new[] { Pending, Accepted, Rejected, InProgress, Delivered, Canceled };

        public static DeliveryRequestStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new InvalidEnumArgumentException($"Possible values for DeliveryRequestStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static DeliveryRequestStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new InvalidEnumArgumentException($"Possible values for DeliveryRequestStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}