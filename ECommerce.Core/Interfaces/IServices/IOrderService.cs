using ECommerce.Core.Entities;
using ECommerce.Core.Entities.BusketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(string BasketId, string Email, AddressDto address);
    }
}
