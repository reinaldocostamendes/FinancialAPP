using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) => Database.EnsureCreated();

        public DbSet<BuyRequest> BuyRequests { get; set; }
        public DbSet<CashBook> CashBooks { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<OrderProducts>().HasOne<Order>(o => o.Order).WithMany(p => p.OrderProducts)
                 .HasForeignKey(e => e.OrderId).IsRequired(true).OnDelete(DeleteBehavior.Cascade);*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string ObterStringConexao()
        {
            string strcon = "Initial Catalog = FinancialAppDockerDb; Data Source=sqldatav2; Persist Security Info = True; User ID = SA; Password = Numsey#2022";
            return strcon;
        }
    }
}