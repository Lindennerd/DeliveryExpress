namespace DeliveryExpress.Application.DeliveryRequestApplication.Commands.Client
{
    public class CreateClient
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}