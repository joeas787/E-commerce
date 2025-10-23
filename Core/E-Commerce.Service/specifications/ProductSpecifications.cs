using E_Commerce.Domain.Entities.Products;
using E_Commerce.Service.specifications;
using E_Commerce.Shared.DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.specifications
{
    public class ProductSpecifications : BaseSpecifications<Product>
    {
        public ProductSpecifications(ProductParameters parameters) :
           base (p=>(!parameters.BrandId.HasValue||p.BrandId==parameters.BrandId.Value)&& (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId.Value)
           &&(string.IsNullOrWhiteSpace(parameters.Search)||p.Name.Contains(parameters.Search))) 
        { 
        
             AddInclude(p=>p.ProductType);
            AddInclude(p=>p.ProductBrand);
            switch (parameters.Sort) { 
            
            case ProductSort.NameAscending:
                    AddOrderBy(p => p.Name);
                    break;
             case ProductSort.NameDescending:
                    AddOrderByDesc(p => p.Name);
                    break;
                case ProductSort.PriceAscending:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSort.PriceDescending:
                    AddOrderByDesc(p => p.Price);
                    break;
                    default:
                    AddOrderBy(p=>p.Name);
                    break;





            }

            Paginated(parameters.Size, parameters.index);





            
        
        }

        public ProductSpecifications(int id) :
         base(p=>p.Id==id)
        {

            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);


        }
    }
}
