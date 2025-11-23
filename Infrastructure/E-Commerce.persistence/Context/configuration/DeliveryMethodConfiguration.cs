using E_Commerce.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.persistence.Context.configuration
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(x => x.Price).HasColumnType("decimal(10,2)");

            builder.Property(x => x.ShortName).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.DeliveryTime).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnType("varchar").HasMaxLength(100);
        }
    }
}
