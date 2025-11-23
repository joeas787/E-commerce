using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DTO.UserOrder
{
    public record OrderRequest(AdressDTO Address,string BasketId, int DeliveryMethodId);
    
    
}
