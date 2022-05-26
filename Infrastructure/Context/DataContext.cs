using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) => Database.EnsureCreated();

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
            string strcon = "Server=Reinaldo\\SQLEXPRESS;Database=FinancialAppDb;Integrated Security=True";
            return strcon;
        }
    }
}