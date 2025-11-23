using E_Commerce.Shared.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServiceAbstraction
{
    public interface IAuthService
    {
        Task<UseResponse> LoginAsync(LoginRequest loginRequest);
        Task<UseResponse> RegisterAsync(RegisterRequest registerRequest);
        Task<bool> CheckEmailAsync(string email);


    }
}
