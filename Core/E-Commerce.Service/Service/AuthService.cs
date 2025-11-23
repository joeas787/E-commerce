using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Service.Contracts;
using E_Commerce.Service.Exceptions;
using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Service
{
    public class AuthService(UserManager<ApplicationUser> _userManager, ITokenService tokenService) : IAuthService
    {
        public async Task<bool> CheckEmailAsync(string email)
        {
           var cheak= await _userManager.FindByEmailAsync(email);
            if (cheak != null) return true;
            return false;
        }

        public async Task<UseResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
                throw new Exception("Invalid email or password");

            var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!result)
                throw new Exception("Invalid email or password");

            var roles = await _userManager.GetRolesAsync(user);
            var token = tokenService.GetToken(user, roles);

            return new UseResponse(user.Email, user.DisplayName, token);
        }

        public async Task<UseResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            var user = new ApplicationUser
            {
                Email = registerRequest.Email,
                DisplayName = registerRequest.DisplayName,
                UserName = registerRequest.UserName,
                PhoneNumber = registerRequest.PhoneNumber



            };

            var result= await _userManager.CreateAsync(user,registerRequest.Email);

            var token = tokenService.GetToken(user, []);
            return new UseResponse(user.Email, user.DisplayName, token);
            
        }
    }
}
