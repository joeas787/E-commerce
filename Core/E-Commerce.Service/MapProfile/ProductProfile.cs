using AutoMapper;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.Shared.DTO.Products;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.MapProfile;

public class ProductProfile : Profile
{
   public ProductProfile() { 
    
    CreateMap<Product,ProductResponse>().ForMember(e=>e.Brand,o=>o.MapFrom(e=>e.ProductBrand.Name))
            .ForMember(e => e.Type, o => o.MapFrom(e => e.ProductType.Name))
            .ForMember(e => e.PictureUrl, o => o.MapFrom<ProductPictureUrl>()) ;

        CreateMap<ProductBrand, BrandResponse>();
        CreateMap<ProductType,TypeResponse>();
    }  

}
internal class ProductPictureUrl(IConfiguration configuration)
    : IValueResolver<Product, ProductResponse, string?>
{
    public string? Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrWhiteSpace(source.PictureUrl))
            return null;
        return $"{configuration["BaseUrl"]}{source.PictureUrl}";
    }
}