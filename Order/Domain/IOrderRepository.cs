namespace Order.Domain
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task<Order> AddAsync(Order order);
        Task SaveChangesAsync();
    }
}