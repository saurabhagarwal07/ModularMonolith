using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public static class OrdersModule
    {
        public static IServiceCollection AddOrdersModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication();
            return services;
        }

        public static IEndpointRouteBuilder MapOrdersEndpoints(
            this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/orders", (string product, IOrderService service) =>
            {
                var order = service.Create(product);
                return Results.Ok(order);
            });

            app.MapGet("/api/orders/{id}", (Guid id, IOrderService service) =>
            {
                var order = service.GetById(id);
                return order is not null ? Results.Ok(order) : Results.NotFound();
            });

            return app;
        }
    }

}
