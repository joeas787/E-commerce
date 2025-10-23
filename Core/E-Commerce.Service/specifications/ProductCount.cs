using E_Commerce.Domain.Entities.Products;
using E_Commerce.Shared.DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.specifications
{
    public sealed class ProductCount : BaseSpecifications<Product>
    {
        public ProductCount(ProductParameters parameters) : base(p => (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId.Value) && (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId.Value)
           && (string.IsNullOrWhiteSpace(parameters.Search) || p.Name.Contains(parameters.Search)))
        {




        }
    }
}
