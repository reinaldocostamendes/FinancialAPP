﻿using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuyRequest_Application.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.ProductCategory).IsRequired();
            builder.Property(x => x.ProductDescription).IsRequired();
            builder.Property(x => x.BuyRequestId).IsRequired();
            builder.Property(x => x.Total).IsRequired();
        }
    }
}