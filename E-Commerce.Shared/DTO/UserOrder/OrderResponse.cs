using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DTO.UserOrder
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; } = default!;
        public ICollection<OrderItemDTO> Items { get; set; } = [];
        public string DeliveryMethod { get; set; } = default!;
        public decimal? DeliveryMethodCost { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        
        public AdressDTO Address { get; set; } = default!;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public string Status { get; set; } 
        public string PaymetIntentId { get; set; } = string.Empty;

    }
}
