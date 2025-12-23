using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain
{
    public class Order
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string ProductName { get; private set; }

        public Order(string productName)
        {
            ProductName = productName;
        }
    }

}
