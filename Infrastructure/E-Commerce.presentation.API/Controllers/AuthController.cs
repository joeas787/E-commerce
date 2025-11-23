using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO.Auth;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.presentation.API.Controllers
{
    public class AuthController(IAuthService authService) : APIBaseController
    {
        [HttpPost("Register")]
        public  async Task< ActionResult<UseResponse>> Register(RegisterRequest register)
        {
            var result= await authService.RegisterAsync(register);
            return Ok(result);



        }
        [HttpPost("Login")]
        public async Task<ActionResult<UseResponse>> Login(LoginRequest request)
        {
            var result = await authService.LoginAsync(request);
            return Ok(result);



        }
        [HttpGet("CheckEmail")]
        public async Task<ActionResult<bool>> Check(string email)
        {
            var result = await authService.CheckEmailAsync(email);
            return Ok(result);
        }

    }
}
