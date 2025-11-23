using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO.UserOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.presentation.API.Controllers
{
    [Authorize]
    public class OrdersController(IOrderService orderService) : APIBaseController
    {
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Create(OrderRequest orderRequest,CancellationToken cancellationToken)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var result = await orderService.CreateAsync(orderRequest, email,cancellationToken);

            return Ok(result);




        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<OrderResponse>> Get(Guid id,CancellationToken cancellationToken) {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var order= await orderService.GetOrderAsync(email,id,cancellationToken);
            return Ok(order);
        
        }
        [HttpGet]
        public async Task<ActionResult<OrderResponse>> GetAll(CancellationToken cancellationToken)
        {
            var email= User.FindFirstValue(ClaimTypes.Email);
            var order = await orderService.GetUserEmailAsync(email,cancellationToken);
            return Ok(order);

        }


        [HttpGet("DeliveryMethods")]
        public async Task<ActionResult<IEnumerable<DeliveryMethodResponse>>> GetDeliveryMethod(CancellationToken cancellationToken)
        {

            var methods= await orderService.GetDeliveryMethodsAsync(cancellationToken);
            return Ok(methods);


        }
    }
}
