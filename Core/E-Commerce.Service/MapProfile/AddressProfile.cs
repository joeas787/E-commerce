using AutoMapper;
using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.MapProfile
{
    internal class AddressProfile : Profile
    {
        public AddressProfile() { 
        CreateMap<Address,AdressDTO>().ReverseMap();
        }
    }
}
