using E_Commerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.specifications
{
    internal class GetProductById (List<int> Id): BaseSpecifications<Product>(p=>Id.Contains(p.Id));
    
    
}
