﻿

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.persistence.Context.configuration;

internal class BrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.Property(p => p.Name).HasColumnType("VarChar").HasMaxLength(256);
    }
}
