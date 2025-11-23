using E_Commerce.Shared.DTO;
using E_Commerce.Shared.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServiceAbstraction
{
    public interface IUserService
    {
        Task<UseResponse> GetByEmailAsync(string email);

        Task<AdressDTO> GetAddressAsync(string email);

        Task<AdressDTO> UpdateAddressAsync(string email, AdressDTO adress);
    }
}
