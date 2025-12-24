using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Contracts;
using Order.Domain;

namespace Order.Application
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderResponse> CreateAsync(CreateOrderRequest request)
        {
            var order = Domain.Order.Create(request.ProductName);
            await _repository.AddAsync(order);
            await _repository.SaveChangesAsync();

            return new OrderResponse(
                order.Id,
                order.ProductName,
                order.CreatedAt,
                order.Status.ToString());
        }

        public async Task<OrderResponse?> GetByIdAsync(Guid id)
        {
            var order = await _repository.GetByIdAsync(id);
            
            return order is null
                ? null
                : new OrderResponse(
                    order.Id,
                    order.ProductName,
                    order.CreatedAt,
                    order.Status.ToString());
        }
    }
}
