using AutoMapper;
using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Service.Contracts;
using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO;
using E_Commerce.Shared.DTO.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Service
{
    internal class UserService(UserManager<ApplicationUser> userManager,IMapper mapper ,ITokenService tokenService) : IUserService
    {
        public async Task<AdressDTO> GetAddressAsync(string email)
        {
            var user = await userManager.Users.Include(e=>e.Address).FirstOrDefaultAsync(x=>x.Email==email);

            if (user == null)
                throw new Exception("Not found");
            if (user.Address == null)
                throw new Exception("address Not found");
            return mapper.Map<AdressDTO>(user.Address);

        }

        public async Task<UseResponse> GetByEmailAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
                throw new Exception("Invalid email or not found");
            var roles= await userManager.GetRolesAsync(user);
            return new UseResponse(user.Email,user.DisplayName,tokenService.GetToken(user,roles));
        }

        public async Task<AdressDTO> UpdateAddressAsync(string email, AdressDTO address)
        {
            var user = await userManager.Users.Include(e => e.Address).FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                throw new Exception("Not found");
            

                if (user.Address != null)
                {
                    user.Address.FirstName = address.FirstName;
                    user.Address.LastName = address.LastName;
                    user.Address.Street = address.Street;
                    user.Address.City = address.City;
                    user.Address.Country = address.Country;
                }
                else 
                {
                    user.Address = mapper.Map<Address>(address);
                }

            await userManager.UpdateAsync(user);

            return mapper.Map<AdressDTO>(user.Address);
        }
    }
}
