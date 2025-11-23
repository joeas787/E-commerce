



using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Domain.Entities.OrderEntities;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.persistence.Authcontext;
using E_Commerce.persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;

namespace E_Commerce.persistence.DbInitializer;

public class Dbinitializer(ApplicationDbContext appDbContext, AuthDbContext authDbContext, RoleManager<IdentityRole> roleManager
    , UserManager<ApplicationUser> userManager, ILogger<Dbinitializer> logger)
    : IDbInitializer
{
    public async Task initializerAsync()
    {
        try
        {
            if ((await appDbContext.Database.GetPendingMigrationsAsync()).Any())
                await appDbContext.Database.MigrateAsync();

            if (!appDbContext.ProductBrands.Any())
            {
               
                var BrandsData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Persistence\Context\DataSeed\brands.json");
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,

                };

                // Deserialize => Convert from String to C# Object
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData, option);

                if (brands != null && brands.Any())
                {
                    appDbContext.ProductBrands.AddRange(brands);
                    await appDbContext.SaveChangesAsync();
                }
            }
            if (!appDbContext.ProductTypes.Any())
            {
                // Read from the file
                var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Persistence\Context\DataSeed\types.json");

                // Deserialize => Convert from String to C# Object
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                if (types != null && types.Any())
                {
                    appDbContext.ProductTypes.AddRange(types);
                    await appDbContext.SaveChangesAsync();
                }
            }
            if (!appDbContext.Products.Any())
            {
               
                var ProductsData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Persistence\Context\DataSeed\products.json");

                // Deserialize => Convert from String to C# Object
                var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                if (products != null && products.Any())
                {
                    appDbContext.Products.AddRange(products);
                    await appDbContext.SaveChangesAsync();
                }
            }
            if (!appDbContext.DeliveryMethods.Any())
            {
                
                var DeliveryMethod = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Persistence\Context\DataSeed\delivery.json");

                
                var Delivery = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethod);

                if (Delivery != null && Delivery.Any())
                {
                    appDbContext.DeliveryMethods.AddRange(Delivery);
                    await appDbContext.SaveChangesAsync();
                }
            }

        }
        catch (Exception ex)
        {
            {
                throw;

            }
        }
    }

    public async Task initializerAuthAsync()
    {
        await authDbContext.Database.MigrateAsync();


        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        }

        if (!userManager.Users.Any())
        {
            var superAdminUser = new ApplicationUser
            {
                DisplayName = "Super Admin",
                Email = "SuperAdmin@gmail.com",
                UserName = "SuperAdmin",
                PhoneNumber = "0123465789"
            };

            var adminUser = new ApplicationUser
            {
                DisplayName = "Admin",
                Email = "Admin@gmail.com",
                UserName = "Admin",
                PhoneNumber = "0123465789"
            };

            await userManager.CreateAsync(superAdminUser, "Passw0rd");
            await userManager.CreateAsync(adminUser, "Passw0rd");


            await userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}