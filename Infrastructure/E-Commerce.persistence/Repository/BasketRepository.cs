using E_Commerce.Domain.Entities.Basket;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.persistence.Repository
{
    internal class BasketRepository(IConnectionMultiplexer multiplexer) : IBasketRepository
    {
        private readonly IDatabase database = multiplexer.GetDatabase();
        public async Task<CustomerBasket> CreateOrUpdateAsync(CustomerBasket basket, TimeSpan? TTL = null)
        {
            var json =JsonSerializer.Serialize(basket);

            await database.StringSetAsync(basket.Id, json,TTL ?? TimeSpan.FromDays(7) );
            return await GetAsync(basket.Id);
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            return await database.KeyDeleteAsync(Id);
        }

        public async Task<CustomerBasket?> GetAsync(string Id)
        {
            var basket = await database.StringGetAsync(Id);

            if(basket.IsNullOrEmpty)
                return null;
            return JsonSerializer.Deserialize<CustomerBasket>(basket!);
        }
    }
}
