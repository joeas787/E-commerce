using AutoMapper;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Basket;
using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DTO.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Service;

public class BasketService (IBasketRepository basketRepository, IMapper mapper) : IBasketService
{
    public async Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO)
    {
        var basket = mapper.Map<CustomerBasket>(basketDTO);
        var updatedBasket = await basketRepository.CreateOrUpdateAsync(basket);
        return mapper.Map<CustomerBasketDTO>(updatedBasket);
    }

    public Task DeleteAsync(string id)
        => basketRepository.DeleteAsync(id);

    public async Task<CustomerBasketDTO> GetBasketByIdAsync(string id)
    {
        var basket = await basketRepository.GetAsync(id);
        return mapper.Map<CustomerBasketDTO>(basket);
    }
}
