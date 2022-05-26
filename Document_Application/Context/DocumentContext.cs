using Infrastructure.Context;
using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Document_Application.Context
{
    public class DocumentContext : DataContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }
    }
}