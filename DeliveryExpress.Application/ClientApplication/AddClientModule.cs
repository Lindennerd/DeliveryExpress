using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryExpress.Application.ClientApplication
{
    public static class ClientModule
    {
        public static IServiceCollection AddClientModule(this IServiceCollection services)
        {
            _ = services.AddMediatR(typeof(ClientModule).Assembly);
            return services;
        }
    }
}