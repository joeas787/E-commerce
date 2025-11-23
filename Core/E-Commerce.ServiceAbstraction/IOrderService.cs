using E_Commerce.Shared.DTO.UserOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.ServiceAbstraction
{
    public interface IOrderService
    {
        Task<OrderResponse>CreateAsync(OrderRequest orderRequest,string email,CancellationToken cancellationToken);
        Task<IEnumerable<DeliveryMethodResponse>> GetDeliveryMethodsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<OrderResponse>> GetUserEmailAsync(string email, CancellationToken cancellationToken);
        Task<OrderResponse> GetOrderAsync(string email, Guid Id, CancellationToken cancellationToken);
    }
}
