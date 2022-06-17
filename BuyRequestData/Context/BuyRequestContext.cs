using BuyRequestData.Configuration;
using BuyRequestDomain.Entity;
using Infrastructure.Context;
using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyRequestData.Context
{
    public class BuyRequestContext : DataContext
    {
        public BuyRequestContext(DbContextOptions<BuyRequestContext> options) : base(options)
        {
        }

        public DbSet<BuyRequest> BuyRequests { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BuyRequestConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}