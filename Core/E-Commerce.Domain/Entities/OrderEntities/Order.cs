using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities.OrderEntities
{
    public class Order : Entity<Guid>
    {
        public ICollection<OrderItem> Items { get; set; } = [];
        public DeliveryMethod? DeliveryMethod { get; set; }
        public int? DeliveryMethodId { get; set; }
        public decimal SubTotal { get; set; }
        public string UserEmail { get; set; } = default!;
        public OrderAddress Address { get; set; }=default!;
        public DateTimeOffset OrderDate {  get; set; }=DateTimeOffset.Now;
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public string PaymetIntentId { get; set; }=default!;

    }
    public class OrderAddress
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;


    }
   
}
