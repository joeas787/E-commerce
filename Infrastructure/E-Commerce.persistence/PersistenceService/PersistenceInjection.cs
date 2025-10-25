

using E_Commerce.persistence.Context;
using E_Commerce.persistence.DbInitializer;
using E_Commerce.persistence.Repository;
using E_Commerce.persistence.Service;
using E_Commerce.ServiceAbstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace E_Commerce.persistence.PersistenceService;

public static class PersistenceInjection
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddSingleton<IConnectionMultiplexer>(c =>
        {

            return ConnectionMultiplexer.Connect(configuration.GetConnectionString("Radis")!);


        });
        services.AddDbContext<ApplicationDbContext>( options => {

            var connection = configuration.GetConnectionString("SQL");

            options.UseSqlServer(connection);


        });
        services.AddScoped<ICashService, CashService>();
        services.AddScoped<IDbInitializer, Dbinitializer>();
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        return services;


    }    
}
