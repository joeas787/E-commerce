using E_Commerce.Shared.DTO.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServiceAbstraction
{
    public interface IPaymentService
    {
        Task<CustomerBasketDTO> CreateOrUpdatePaymentIntentAsync(string basketId);
        


    }
}
