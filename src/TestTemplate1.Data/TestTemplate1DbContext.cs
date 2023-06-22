using MassTransit;
using Microsoft.EntityFrameworkCore;
using TestTemplate1.Core.Entities;

namespace TestTemplate1.Data
{
    public class TestTemplate1DbContext : DbContext
    {
        public TestTemplate1DbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Foo> Foos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }
}
