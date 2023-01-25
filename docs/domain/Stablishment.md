# Stablishment Aggregator Root

```csharp
class Stablishment
{
    public string Id { get; set; }
    public Name Name { get; set; }
    public Address Address { get; set; }
    public string Phone { get; set; }
    public List<Contact> Contacts { get; set; }
    public List<Product> AvailableProducts { get; set; }
    public List<Client> Clients { get; set; }

    // Commands
    public void AddContact(Contact contact);
    public void RemoveContact(Contact contact);
    public void AddProduct(Product product);
    public void RemoveProduct(Product product);
    public void AddClient(Client client);
    public void RemoveClient(Client client);

    //Queries
    public List<Contact> GetContacts();
    public List<Product> GetProducts();
    public List<Client> GetClients();
```

```json
{
    "id": "string",
    "name": "string",
    "address": {
        "street": "My Street",
        "number": "000",
        "complement": "My Complement",
        "neighborhood": "My Neighborhood",
        "city": "My City",
        "state": "My State",
        "country": "My Country",
        "zip_code": "00000000"
      },
    "phone": "string",
    "contacts": [
        {"contactId": "string"}
        {"contactId": "string"}
        {"contactId": "string"}
        {"contactId": "string"}
    ],
    "availableProducts": [
        {"productId": "string"}
        {"productId": "string"}
        {"productId": "string"}
        {"productId": "string"}
    ],
    "clients": [
        {"clientId": "string"}
        {"clientId": "string"}
        {"clientId": "string"}
        {"clientId": "string"}
    ]
}
```