using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryExpress.Application.DeliveryRequestApplication.DependencyInjection
{
    public static class DeliveryRequestModule
    {
        public static IServiceCollection AddDeliveryRequestModule(this IServiceCollection services)
        {
            _ = services.AddMediatR(typeof(DeliveryRequestModule).Assembly);
            return services;
        }
    }
}