using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus Status { get; private set; }

        private Order() { } // EF Core

        public static Order Create(string productName)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                ProductName = productName,
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Pending
            };
        }

        public void Complete()
        {
            Status = OrderStatus.Completed;
        }
    }

    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }
}
