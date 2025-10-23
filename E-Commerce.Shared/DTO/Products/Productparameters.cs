using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DTO.Products
{
    public class ProductParameters
    {
        private const int M_Size = 10;

        private const int D_Size =5;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Search { get; set; }
        public ProductSort Sort { get; set; }
        private int size = D_Size;
        public int Size {get => size; 
                
                set=> size =value>M_Size ?  M_Size: size<D_Size? D_Size:value;
                
                }

        public int index { get; set; } = 1;

    }
}
public enum ProductSort
{
    NameAscending=1,
    NameDescending=2,
    PriceAscending=3,
    PriceDescending=4





}
