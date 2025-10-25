using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities.Basket;

public class BasketItem
{
#nullable disable
    public string Id { get; set; }
    public string Name { get; init; }

    public string PictureUrl { get; init; }
    public decimal Price { get; init; }
    public int Quantatiy { get; init; }
}
