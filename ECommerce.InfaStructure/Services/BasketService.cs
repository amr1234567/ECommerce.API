// Ignore Spelling: Infa

using ECommerce.Core.Entities.BusketEntities;
using ECommerce.Core.Interfaces.IServices;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.InfaStructure.Services
{
    public class BasketService : IBasketService
    {
        private readonly IDatabase _database;

        public BasketService(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket> GetBasketAsync(string Id)
        {
            var basket = await _database.StringGetAsync(Id);

            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket> UpdateOrCreateBasketAsync(CustomerBasket basket)
        {
            var newBasket = await _database.StringSetAsync(basket.BusketId, JsonSerializer.Serialize(basket), TimeSpan.FromHours(1));

            if (!newBasket) return new CustomerBasket();

            return await GetBasketAsync(basket.BusketId);
        }
    }
}
