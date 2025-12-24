using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Domain; // Add this if the Order type is defined in Order.Domain namespace
using Order.Contracts;

namespace Order.Application
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateAsync(CreateOrderRequest request);
        Task<OrderResponse?> GetByIdAsync(Guid id);
    }
}
