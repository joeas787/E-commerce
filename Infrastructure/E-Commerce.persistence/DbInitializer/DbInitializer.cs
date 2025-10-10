



using E_Commerce.Domain.Entities.Products;
using E_Commerce.persistence.Context;
using System;
using System.Text.Json;

namespace E_Commerce.persistence.DbInitializer;

public class Dbinitializer(ApplicationDbContext appDbContext)
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
                // Read from the file
                var BrandsData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Persistence\Context\DataSeed\brands.json");
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,

                };

                // Deserialize => Convert from String to C# Object
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData,option);

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
                // Read from the file
                var ProductsData = await File.ReadAllTextAsync(@"..\Infrastructure\E-Commerce.Persistence\Context\DataSeed\products.json");

                // Deserialize => Convert from String to C# Object
                var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                if (products != null && products.Any())
                {
                    appDbContext.Products.AddRange(products);
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
}
