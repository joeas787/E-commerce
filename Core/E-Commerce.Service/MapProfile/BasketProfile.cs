using AutoMapper;
using E_Commerce.Domain.Entities.Basket;
using E_Commerce.Shared.DTO.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.MapProfile
{
    internal class BasketProfile : Profile
    {

        public BasketProfile() { 
        
        CreateMap<CustomerBasket,CustomerBasketDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemDTO>().ReverseMap();

        }
    }
}
