using System.Collections.ObjectModel;
using DeliveryExpress.Domain.ClientAggregator;
using DeliveryExpress.Domain.Common.AddressValueObject;
using DeliveryExpress.Domain.ProductAggregator;
using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.StablishmentAggregator
{
    public class Stablishment : Entity, IAggregateRoot
    {
        public string Name { get; } = null!;
        public Address Address { get; } = null!;
        public string Phone { get; } = null!;

        private readonly List<Contact> _contacts = null!;

        private readonly List<Product> _products = null!;
        private readonly List<Client> _clients = null!;

        public ReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();
        public ReadOnlyCollection<Product> Products => _products.AsReadOnly();
        public ReadOnlyCollection<Client> Clients => _clients.AsReadOnly();

        protected Stablishment()
        {
        }

        public Stablishment(string name, Address address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            _ = _contacts.Remove(contact);
        }

        public void UpdateContact(Contact contact)
        {
            int index = _contacts.FindIndex(c => c.Id == contact.Id);
            _contacts[index] = contact;
        }

        public void AddProduct(Product productId)
        {
            _products.Add(productId);
        }

        public void RemoveProduct(int productId)
        {
            _products
                .Where(x => x.Id == productId)
                .ToList()
                .ForEach(x => _products.Remove(x));
        }

        public void AddClient(Client clientId)
        {
            _clients.Add(clientId);
        }

        public void RemoveClient(int clientId)
        {
            _clients
                .Where(x => x.Id == clientId)
                .ToList()
                .ForEach(x => _clients.Remove(x));
        }
    }
}