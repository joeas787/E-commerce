using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities.OrderEntities
{
    public class OrderItem : Entity<Guid>
    {

        public ProductInOrderItem Product { get; set; }
        public decimal Price { get; set; }
        public int Quantatiy { get; set; }
        public Guid OrderId { get; set; }
    }
    public class ProductInOrderItem
    {

        public int ProductId { get; set; }
        public string Name { get; set; }

        public string PictureUrl { get; set; }



    }
}
