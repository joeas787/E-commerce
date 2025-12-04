using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Service.Service;
using E_Commerce.ServiceAbstraction;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_Commerce.Service.Injection;

public static class ApplicationInjection
{
public static IServiceCollection AddServices(this IServiceCollection services)
    {

        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IAuthService, AuthService>();
      

        return services;
    }

}
