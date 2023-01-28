using DeliveryExpress.Domain.ClientAggregator;
using DeliveryExpress.Domain.DeliveryRequestAggregator;
using DeliveryExpress.Domain.SeedWork;
using DeliveryExpress.Infrastructure.Client;
using DeliveryExpress.Infrastructure.DeliveryRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryExpress.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddDbContext<DeliveryExpressContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DeliveryExpressDatabase"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    _ = sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                    _ = sqlOptions.MigrationsAssembly("DeliveryExpress.Api"); // ugly af
                })
            );

            _ = services.AddScoped<IUnitOfWork, DeliveryExpressContext>();

            return services;
        }

        public static IServiceCollection AddDeliveryRequestRepository(this IServiceCollection services)
        {
            _ = services.AddScoped<IDeliveryRequestRepository, DeliveryRequestRepository>();
            return services;
        }

        public static IServiceCollection AddClientRepository(this IServiceCollection services)
        {
            _ = services.AddScoped<IClientRepository, ClientRepository>();
            return services;
        }
    }
}