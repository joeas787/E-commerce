using E_Commerce.Domain.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.specifications
{
    public class OrderByEmailSpecifications : BaseSpecifications<Order>
    {
      public OrderByEmailSpecifications(string email) : base(o=>o.UserEmail==email){

            AddInclude(o => o.DeliveryMethod);
            AddInclude(o=>o.Items);
            AddOrderBy(o=>o.OrderDate);
        }
    }
}
