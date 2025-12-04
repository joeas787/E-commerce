using AutoMapper;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.Service.specifications;
using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO.Basket;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product= E_Commerce.Domain.Entities.Products.Product;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerce.Infrastructure.Service
{
    public class PaymentService(IBasketRepository basketRepository,IMapper mapper,
        IUnitOfWork unitOfWork,IConfiguration configuration) : IPaymentService
    {
        public async Task<CustomerBasketDTO> CreateOrUpdatePaymentIntentAsync(string basketId)
        {
            var skey= configuration[""];
            if (skey == null)
                throw new Exception("Failed Key");
            StripeConfiguration.ApiKey=skey;
            var basket = await basketRepository.GetAsync(basketId);
            if (basket == null)
                throw new Exception("Basket Not Found");
            if (basket.DeliveryMethodId == null)
                throw new Exception("Method is Required");
            var Methode = await unitOfWork.GetRepository<DeliveryMethod,int>().GetByIdAsync(basket.DeliveryMethodId.Value);
            if (Methode == null)
                throw new Exception("Methode Not Found");
            basket.ShippingPrice = Methode.Price;
            var productRepo = unitOfWork.GetRepository<Product,int>();
            var productIds = basket.item.Select(x => x.Id).ToList();

            var productsDictionary = (await productRepo
                .GetAllAsync(new GetProductById(productIds)))
                .ToDictionary(x => x.Id);

            

            foreach (var item in basket.item)
            {
                if (productsDictionary.TryGetValue(item.Id, out Product? product))
                {

                    item.Price = product.Price;
                    item.PictureUrl = product.PictureUrl;
                    item.Name = product.Name;


                }
               
            }
            long amount = (long)(basket.item.Sum(x => x.Price * x.Quantatiy) * 100);
            var service= new PaymentIntentService();
            if(basket.PaymentIntentId is null)
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "USD",
                    PaymentMethodTypes = ["Card"]
                };

                var paymentIntent = await service.CreateAsync(options);
                basket.PaymentIntentId = paymentIntent.Id;
                basket.ClientSecret = paymentIntent.ClientSecret;
            }
            else
            {

                var options = new PaymentIntentUpdateOptions
                {
                    Amount = amount
                };

                await service.UpdateAsync(basket.PaymentIntentId, options);
            }

          await  basketRepository.CreateOrUpdateAsync(basket);
            return mapper.Map<CustomerBasketDTO>(basket);

        }
    }
}
