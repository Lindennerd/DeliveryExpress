using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.ClientAggregator
{
    public interface IClientRepository : IRepository<Client>
    {
        Client Add(Client client);
        void Update(Client client);
        Task<Client> GetByClientIdAsync(int clientId);
    }
}