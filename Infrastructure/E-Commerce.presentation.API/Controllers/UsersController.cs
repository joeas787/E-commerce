using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO;
using E_Commerce.Shared.DTO.Auth;
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
    public class UsersController(IUserService userService) : APIBaseController
    {
        [HttpGet] 
        public async Task<ActionResult<UseResponse>> GetUser()
        {
            string email = User.FindFirstValue(ClaimTypes.Email)!;

            var result = await userService.GetByEmailAsync(email);
            return Ok(result);
        }
        [HttpGet("Address")]
        public async Task<ActionResult<AdressDTO>> GetAddress()
        {
            string email = User.FindFirstValue(ClaimTypes.Email)!;

            var result = await userService.GetAddressAsync(email);
            return Ok(result);
        }
        [HttpPut("Address")]
        public async Task<ActionResult<AdressDTO>> UpdateAddress(AdressDTO address) 
        {
            string email = User.FindFirstValue(ClaimTypes.Email)!;

            var result = await userService.UpdateAddressAsync(email, address);
            return Ok(result);
        }

    }
}
