using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DTO.UserOrder
{
    public class DeliveryMethodResponse
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string DeliveryTime { get; set; } = default!;

        public decimal Cost { get; set; }
    }
}
