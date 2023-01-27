using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.StablishmentAggregator
{
    public interface IStablishmentRepository : IRepository<Stablishment>
    {
        Stablishment Add(Stablishment stablishment);
        void Update(Stablishment stablishment);
        Task<Stablishment> GetByStablishmentIdAsync(int stablishmentId);
    }
}