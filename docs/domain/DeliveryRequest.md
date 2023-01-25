# Delivery Request Aggregator Root

```csharp
class DeliveryRequest 
{
    public string Id { get; set; }
    public string ClientId { get; set; }
    public string StablishmentId { get; set; }
    public string DeliveryStatus { get; set; }
    public DateTime DeliveryDate { get; set; }
    public List<DeliveryItem> DeliveryItems { get; set; }
    public Driver Driver { get; set; }

    // Commands
    public void AddDeliveryItem(DeliveryItem deliveryItem);
    public void RemoveDeliveryItem(DeliveryItem deliveryItem);
    public void UpdateDeliveryStatus(string deliveryStatus);
    public void UpdateDeliveryDate(DateTime deliveryDate);
    public void UpdateDriver(Driver driver);
}
```

```json
{
    "id": "string",
    "clientId": "string",
    "stablishmentId": "string",
    "deliveryStatus": "pending",
    "deliveryDate": "2020-01-01T00:00:00.000Z",
    "deliveryItems": [
        {
            "productId": "string",
            "quantity": 0
        }
    ],
    "driver": {
        "id": "string",
        "name": "string",
        "phone": "string"
    }
}
```
