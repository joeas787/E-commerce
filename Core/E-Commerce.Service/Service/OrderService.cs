using AutoMapper;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.Service.specifications;
using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO.UserOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Service
{
    public class OrderService(IUnitOfWork unitOfWork,IMapper mapper,IBasketRepository basketRepository) : IOrderService
    {
        public async Task<OrderResponse> CreateAsync(OrderRequest orderRequest, string email, CancellationToken cancellationToken)
        {
            var basket = await basketRepository.GetAsync(orderRequest.BasketId);
            if (basket == null)
                throw new Exception("Basket Not Found");
            if (basket.PaymentIntentId == null)
                throw new Exception("No found PaymentIntent");
            var method = await unitOfWork.GetRepository<DeliveryMethod,int>().GetByIdAsync(orderRequest.DeliveryMethodId,cancellationToken);
            if (method == null) throw new Exception("Method Not Found");
            var ids=basket.item.Select(x => x.Id).ToList();
            
            var productrepo =  unitOfWork.GetRepository<Product,int>();
            var products=(await productrepo.GetAllAsync(new GetProductById(ids),cancellationToken)).ToDictionary(p=>p.Id);
            var orderitems = new List<OrderItem>();
            foreach (var item in basket.item)
            {
               if(products.TryGetValue(item.Id, out Product product)) {
                    var orderitem=new OrderItem { Price = product.Price ,
                    Quantatiy=item.Quantatiy,
                    Product=new ProductInOrderItem
                    {
                        Name=product.Name,
                        PictureUrl=product.PictureUrl,
                        ProductId=product.Id


                    }
                    
                    };

                    orderitems.Add(orderitem);
                }



            }
            var orderrepo = unitOfWork.GetRepository<Order, Guid>();
            var exorder = await orderrepo.GetByAsync(new OrderIntetById(basket.PaymentIntentId));
            if(exorder is not null) 
                orderrepo.Remove(exorder);
            var subtotal=orderitems.Sum(x => x.Quantatiy*x.Price);
            var address=mapper.Map<OrderAddress>(orderRequest.Address);
            var order = new Order
            {
                SubTotal = subtotal,
                Address = address,
                Items = orderitems,
                UserEmail = email,
                DeliveryMethod = method
                ,PaymetIntentId=basket.PaymentIntentId


            };
           

            orderrepo.Add(order);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<OrderResponse>(order);    
        }

        public async Task<OrderResponse> GetOrderAsync(string email,Guid Id, CancellationToken cancellationToken)
        {
            var order = await unitOfWork.GetRepository<Order, Guid>().GetByAsync(new OrderByIdSpecifications(email,Id), cancellationToken);
            if (order == null)
                throw new Exception("Not Found");
            return mapper.Map<OrderResponse>(order);    
        }

        public async Task<IEnumerable<DeliveryMethodResponse>> GetDeliveryMethodsAsync(CancellationToken cancellationToken)
        {

            var methods= await unitOfWork.GetRepository<DeliveryMethod,int>().GetAllAsync(cancellationToken);

            return mapper.Map<IEnumerable<DeliveryMethodResponse>>(methods);


        }

        public async Task<IEnumerable<OrderResponse>> GetUserEmailAsync(string email, CancellationToken cancellationToken)
        {
            var orders = await unitOfWork.GetRepository<Order, Guid>().GetAllAsync(new OrderByEmailSpecifications(email), cancellationToken);

            return mapper.Map<IEnumerable<OrderResponse>>(orders);
        }
    }
}
