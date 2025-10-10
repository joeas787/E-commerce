

using E_Commerce.persistence.Context;
using E_Commerce.persistence.DbInitializer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.persistence.PersistenceService;

public static class PersistenceInjection
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>( options => {

            var connection = configuration.GetConnectionString("SQL");

            options.UseSqlServer(connection);


        });
        services.AddScoped<IDbInitializer, Dbinitializer>();
        return services;


    }    
}
