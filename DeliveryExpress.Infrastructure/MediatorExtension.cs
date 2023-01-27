using DeliveryExpress.Domain.SeedWork;
using DeliveryExpress.Infrastructure.DeliveryRequest;
using MediatR;

namespace DeliveryExpress.Infrastructure
{
    internal static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync<T>(this IMediator mediator, DeliveryExpressContext ctx) where T : Entity
        {
            IEnumerable<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T>> domainEntities = ctx.ChangeTracker
                .Entries<T>()
                .Where(x => x.Entity.DomainEvents?.Any() == true);

            List<INotification> domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (INotification? domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}