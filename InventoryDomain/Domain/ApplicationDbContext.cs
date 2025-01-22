using Microsoft.EntityFrameworkCore;
using System.Reflection;
using InventoryDomain.Model;

namespace InventoryDomain.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> Billitems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // optionsBuilder.UseSqlite("Test.db");

         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}