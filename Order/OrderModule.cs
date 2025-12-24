using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application;
using Order.Contracts;
using Order.Infrastructure;

namespace Order
{
    public static class OrdersModule
    {
        public static IServiceCollection AddOrdersModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfrastructure(configuration);
            return services;
        }

        public static IEndpointRouteBuilder MapOrdersEndpoints(
            this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/orders")
                .WithTags("Orders");

            group.MapPost("/", async (CreateOrderRequest request, IOrderService service) =>
            {
                var order = await service.CreateAsync(request);
                return Results.Created($"/api/orders/{order.Id}", order);
            })
            .WithName("CreateOrder")
            .Produces<OrderResponse>(StatusCodes.Status201Created);

            group.MapGet("/{id:guid}", async (Guid id, IOrderService service) =>
            {
                var order = await service.GetByIdAsync(id);
                return order is not null ? Results.Ok(order) : Results.NotFound();
            })
            .WithName("GetOrder")
            .Produces<OrderResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            return app;
        }
    }
}
