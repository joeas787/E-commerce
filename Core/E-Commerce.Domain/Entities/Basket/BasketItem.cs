using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities.Basket;

public class BasketItem
{
#nullable disable
    public int Id { get; set; }
    public string Name { get; set; }

    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantatiy { get; set; }
}
