using System.Collections.ObjectModel;
using DeliveryExpress.Domain.Common.AddressValueObject;
using DeliveryExpress.Domain.SeedWork;

namespace DeliveryExpress.Domain.StablishmentAggregator
{
    public class Stablishment : Entity, IAggregateRoot
    {
        public string Name { get; } = null!;
        public Address Address { get; } = null!;
        public string Phone { get; } = null!;

        private readonly List<Contact> _contacts = null!;

        private readonly List<int> _products = null!;
        private readonly List<int> _clients = null!;

        public ReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();
        public ReadOnlyCollection<int> Products => _products.AsReadOnly();
        public ReadOnlyCollection<int> Clients => _clients.AsReadOnly();

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

        public void AddProduct(int productId)
        {
            _products.Add(productId);
        }

        public void RemoveProduct(int productId)
        {
            _ = _products.Remove(productId);
        }

        public void AddClient(int clientId)
        {
            _clients.Add(clientId);
        }

        public void RemoveClient(int clientId)
        {
            _ = _clients.Remove(clientId);
        }
    }
}