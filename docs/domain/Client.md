# Client Aggregator Root

```csharp
class Client 
{
    public string Id { get; set; }
    public Name Name { get; set; }
    public Address Address { get; set; }
    public string Phone { get; set; }
    public List<DeliveryRequest> DeliveryRequests { get; set; }

    // Commands
    public void AddDeliveryRequest(DeliveryRequest deliveryRequest);
}
```

```json
    "client": {
      "id": "000000000000000000",
      "name": {
        "firstName": "My First Name",
        "lastName": "My Last Name"
      },
      "phone": "0000000000",
      "deliveryRequests": [
        { "deliveryRequestId": "000000000000000000" } 
      ],
      "address": {
        "street": "My Street",
        "number": "000",
        "complement": "My Complement",
        "neighborhood": "My Neighborhood",
        "city": "My City",
        "state": "My State",
        "country": "My Country",
        "zip_code": "00000000"
      }
    }
```