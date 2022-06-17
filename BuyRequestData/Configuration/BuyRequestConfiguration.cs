using BuyRequestDomain.Entity;
using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyRequestData.Configuration
{
    public class BuyRequestConfiguration : IEntityTypeConfiguration<BuyRequest>
    {
        public void Configure(EntityTypeBuilder<BuyRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Street);
            builder.Property(x => x.City);
            builder.Property(x => x.StreetNumber);
            builder.Property(x => x.Code);
            builder.Property(x => x.DeliveryDate);
            builder.Property(x => x.Client);
            builder.Property(x => x.ClientDescription);
            builder.Property(x => x.ClientEmail);
            builder.Property(x => x.ClientPhone);
            builder.Property(x => x.Complement);
            builder.Property(x => x.CostValue);
            builder.Property(x => x.Discount);
            builder.Property(x => x.ProductsValues);
            builder.Property(x => x.Date);
            builder.HasMany(x => x.Products)
                .WithOne(b => b.BuyRequest)
                .HasForeignKey(f => f.BuyRequestId);
        }
    }
}