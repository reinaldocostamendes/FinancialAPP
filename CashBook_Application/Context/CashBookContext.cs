using Infrastructure.Context;
using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace CashBook_Application.Context
{
    public class CashBookContext : DataContext
    {
        public CashBookContext(DbContextOptions<CashBookContext> options) : base(options)
        {
        }

        public DbSet<CashBook> CashBooks { get; set; }
    }
}