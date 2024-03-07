using ECommerce.Core.Entities.BusketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public List<OrderItem> items { get; set; }
        public double TotalPrice { get; set; }
        public AddressDto Address { get; set; }

        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
    }
}
