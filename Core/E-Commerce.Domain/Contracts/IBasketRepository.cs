using E_Commerce.Domain.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contracts;

public interface IBasketRepository
{
    Task<bool> DeleteAsync(string Id);
    Task<CustomerBasket?> GetAsync(string Id);
    Task<CustomerBasket> CreateOrUpdateAsync(CustomerBasket basket ,TimeSpan? TTL =null);

}
