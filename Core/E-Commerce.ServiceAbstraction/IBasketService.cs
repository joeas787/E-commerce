using E_Commerce.Shared.DTO.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServiceAbstraction
{
    public interface IBasketService
    {

        Task<CustomerBasket> CreateOrUpdateAsync(CustomerBasket customerBasket);
        Task<CustomerBasket> GetBasketByIdAsync(string  Id);

        Task DeleteAsync(string Id);


    }
}
