using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO.Basket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.presentation.API.Attributes;

namespace E_Commerce.presentation.API.Controllers
{
    public class BasketsController(IBasketService basketService) :APIBaseController
    {
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDTO>> Update(CustomerBasketDTO basket)
        {


            return Ok(await basketService.CreateOrUpdateAsync(basket));



        }
       
        [HttpGet]


        public async Task<ActionResult<CustomerBasketDTO>> Get(string id)
        {


            return Ok( await basketService.GetBasketByIdAsync(id));



        }
        [HttpDelete]

        public async Task<ActionResult> Delete(string id) { 
        await basketService.DeleteAsync(id);
        return NoContent();
        
        
        }

    }
}
