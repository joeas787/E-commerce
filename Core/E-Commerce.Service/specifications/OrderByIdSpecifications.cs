using E_Commerce.Domain.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.specifications
{
    public class OrderByIdSpecifications : BaseSpecifications<Order>
    {
        public OrderByIdSpecifications(string email,Guid id) : base(o=>o.Id==id&&o.UserEmail==email) {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.Items);

        }
    }
}
