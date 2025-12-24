using Microsoft.EntityFrameworkCore;
using Order.Domain;

namespace Order.Infrastructure
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Domain.Order> AddAsync(Domain.Order order)
        {
            await _context.Orders.AddAsync(order);
            return order;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}