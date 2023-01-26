using DeliveryExpress.Domain.DeliveryRequestAggregator;
using DeliveryExpress.Infrastructure.DeliveryRequest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryExpress.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<DeliveryExpressContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DeliveryExpressDatabase")));

            //services.AddScoped<IDeliveryRequestRepository, DeliveryRequestRepository>();
            //services.AddScoped<IUnitOfWork, DeliveryExpressContext>();
        }

        public static void AddDeliveryRequestRepository(this IServiceCollection services)
        {
            _ = services.AddScoped<IDeliveryRequestRepository, DeliveryRequestRepository>();
        }
    }
}