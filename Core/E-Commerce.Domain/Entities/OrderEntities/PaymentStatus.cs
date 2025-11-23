using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities.OrderEntities
{
    public enum PaymentStatus
    {
        Pending=0,
        Received=1,
        Failed=2
    }
}
