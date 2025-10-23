using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DTO.Basket;

public class CustomerBasket
{


    public string Id { get; set; }
    public ICollection<ItemBaskect> item { get; set; }
}
