using E_Commerce.Domain.Entities.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.specifications
{
    public class OrderIntetById(string id) : BaseSpecifications<Order>(o=>o.PaymetIntentId==id);
    
}
