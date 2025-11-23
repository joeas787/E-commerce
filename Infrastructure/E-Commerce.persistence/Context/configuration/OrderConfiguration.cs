 global using Order = E_Commerce.Domain.Entities.OrderEntities.Order;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerce.persistence.Context.configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(x=>x.Items).WithOne().HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.DeliveryMethod).WithMany().HasForeignKey(x=>x.DeliveryMethodId).OnDelete(DeleteBehavior.SetNull);
            builder.OwnsOne(x => x.Address, x => x.WithOwner());
            builder.HasIndex(x => x.UserEmail);

            builder.Property(x => x.SubTotal).HasColumnType("decimal(10,2)");

            builder.Property(x => x.UserEmail).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.PaymetIntentId).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Status).HasConversion<string>();
        }
    }
}
