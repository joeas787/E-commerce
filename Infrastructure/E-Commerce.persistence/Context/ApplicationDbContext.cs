



using System.Reflection;

namespace E_Commerce.persistence.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext)
    :DbContext(dbContext)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
