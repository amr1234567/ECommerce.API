using ECommerce.Core.Entities;
using ECommerce.Core.Entities.BusketEntities;
using ECommerce.Core.Interfaces.IServices;
using ECommerce.Core.Interfaces.IUseCases.IBasketUseCases;
using ECommerce.Core.Interfaces.IUseCases.IProductUseCases;
using ECommerce.InfaStructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly WebSiteContext _context;
        private readonly IGetBasketUseCase _getBasket;
        private readonly IGetProductByIdUseCase _getProductById;

        public OrderService(WebSiteContext context, IGetBasketUseCase getBasket, IGetProductByIdUseCase getProductById)
        {
            _context = context;
            _getBasket = getBasket;
            _getProductById = getProductById;
        }

        public async Task<Order> CreateOrder(string BasketId, string Email, AddressDto address)
        {
            var DataBasket = await _getBasket.Execute(BasketId);
            if (DataBasket == null)
                return null;
            var items = new List<OrderItem>();
            foreach (var item in DataBasket.Items)
            {
                var product = await _getProductById.Execute(item.ProductId);
                var orderItem = new OrderItem
                {
                    PriceOfItem = item.Quantity * product.Price,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                items.Add(orderItem);
            }
            var order = new Order
            {
                Address = address,
                Email = Email,
                items = items,
                TotalPrice = items.Sum(i => i.PriceOfItem)
            };

            await _context.Orders.AddAsync(order);
            await _context.OrderItems.AddRangeAsync(items);

            await _context.SaveChangesAsync();
            return order;
        }
    }
}
