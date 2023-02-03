namespace DeliveryExpress.Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id);
        void Update(T entity);
        void Delete(T entity);
    }
}