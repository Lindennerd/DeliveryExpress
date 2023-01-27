using MediatR;

namespace DeliveryExpress.Domain.SeedWork
{
    public abstract class Entity
    {
        int? _requestedHashCode;

        public virtual int Id { get; protected set; }

        public List<INotification> DomainEvents { get; private set; } = null!;
        public void AddDomainEvent(INotification eventItem)
        {
            DomainEvents ??= new List<INotification>();
            DomainEvents.Add(eventItem);
        }
        public void RemoveDomainEvent(INotification eventItem)
        {
            if (DomainEvents is null) return;
            DomainEvents.Remove(eventItem);
        }

        public bool IsTransient()
        {
            return this.Id == default;
        }

        public override bool Equals(object obj)
        {
            if (obj is null or not Entity)
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Entity item = (Entity)obj;
            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31;
                return _requestedHashCode.Value;
            }
            else
            {
                return base.GetHashCode();
            }
        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return Object.Equals(right, null);
            else
                return left.Equals(right);
        }
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        public void ClearDomainEvents()
        {
            DomainEvents?.Clear();
        }
    }
}