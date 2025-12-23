using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Domain; // Ensure we reference the correct namespace for Order

namespace Order.Application
{
    internal class OrderService: IOrderService
    {
        public Order.Domain.Order Create(string productName)
        {
            // Use the constructor to set ProductName, since the setter is private
            return new Order.Domain.Order(productName);
        }

        //Add method to get order by id
        public Order.Domain.Order GetById(Guid id)
        {
            // In a real application, this would retrieve the order from a database
            // Here, we will just return a new order for demonstration purposes
            return new Order.Domain.Order("Sample Product");
        }
    }
}
