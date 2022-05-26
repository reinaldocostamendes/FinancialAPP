using BuyRequest_Application.Configuration;
using Infrastructure.Context;
using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace BuyRequest_Api.Data
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