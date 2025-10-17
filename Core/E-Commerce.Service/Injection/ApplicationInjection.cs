using E_Commerce.Service.Service;
using E_Commerce.ServiceAbstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Injection;

public static class ApplicationInjection
{
public static IServiceCollection AddServices(this IServiceCollection services)
    {


        services.AddScoped<IProductService, ProductService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

}
