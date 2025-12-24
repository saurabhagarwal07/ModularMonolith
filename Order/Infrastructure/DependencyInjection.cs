using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Domain;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Order.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
                options.UseInMemoryDatabase("OrdersDb")); // Replace with real DB

            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}