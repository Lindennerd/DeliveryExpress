namespace DeliveryExpress.Domain.SeedWork;
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync<T>(CancellationToken cancellationToken = default(CancellationToken)) where T : Entity;
    Task<bool> SaveEntitiesAsync<T>(CancellationToken cancellationToken = default(CancellationToken)) where T : Entity;
}