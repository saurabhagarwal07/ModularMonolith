using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Payment
{
    public static class PaymentModule
    {
        public static IServiceCollection AddPaymentModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // services.AddApplication();
            // services.AddInfrastructure(configuration);
            return services;
        }

        public static IEndpointRouteBuilder MapPaymentEndpoints(
            this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/payments")
                .WithTags("Payments");

            // Add payment endpoints here

            return app;
        }
    }
}
