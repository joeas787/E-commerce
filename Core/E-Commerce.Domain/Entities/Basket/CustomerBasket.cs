using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities.Basket
{
    public class CustomerBasket
    {
        public String Id { get; set; } = default!;
       public ICollection<BasketItem> item { get; set; } = [];
    }
}
