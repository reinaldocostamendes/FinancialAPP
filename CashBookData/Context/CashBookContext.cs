using CashBookDomain.Entity;
using Infrastructure.Context;
using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashBookData.Context
{
    public class CashBookContext : DataContext
    {
        public CashBookContext(DbContextOptions<CashBookContext> options) : base(options)
        {
        }

        public DbSet<CashBook> CashBooks { get; set; }
    }
}