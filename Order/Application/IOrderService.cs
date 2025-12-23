using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Domain; // Add this if the Order type is defined in Order.Domain namespace

namespace Order.Application
{
    public interface IOrderService
    {
        Order.Domain.Order Create(string productName); // Fully qualify Order type to avoid ambiguity
        Order.Domain.Order GetById(Guid id);
    }
}
