using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DTO.UserOrder
{
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }

        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantatiy { get; set; }
        
    }
}
