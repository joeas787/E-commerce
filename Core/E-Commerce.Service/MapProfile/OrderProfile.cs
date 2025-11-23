using AutoMapper;
using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Shared.DTO;
using E_Commerce.Shared.DTO.UserOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.MapProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile() {
            CreateMap<Order, OrderResponse>().ForMember(d=>d.DeliveryMethod,o=>o.MapFrom(s=>s.DeliveryMethod.ShortName)).
                ForMember(d => d.DeliveryMethodCost, o => o.MapFrom(s => s.DeliveryMethod.Price)).
                 ForMember(d => d.Total, o => o.MapFrom(s => s.DeliveryMethod.Price+s.SubTotal));
            CreateMap<OrderAddress,AdressDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ForMember(x=>x.ProductId,s=>s.MapFrom(o=>o.Product.ProductId)).
                ForMember(x => x.PictureUrl, s => s.MapFrom(o => o.Product.PictureUrl)).
                ForMember(x => x.Name, s => s.MapFrom(o => o.Product.Name));

            CreateMap<DeliveryMethod,DeliveryMethodResponse>().ForMember(s=>s.Cost,o=>o.MapFrom(x=>x.Price));
        }
    }
}
