using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO.Basket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.presentation.API.Controllers
{
    [Authorize]
    public class PaymentsController(IPaymentService paymentService) : APIBaseController
    {
        [HttpPost("BasketId")]
        public async Task<ActionResult<CustomerBasketDTO>>CreateOrUpdatePaymentIntent(string BasketId)
        {
            var basket = await paymentService.CreateOrUpdatePaymentIntentAsync(BasketId);
            return Ok(basket);


        }
    }
}
