using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF
{
    public class EFDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=.; Initial Catalog=OnlineShop; Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<AccountingDocument> AccountingDocuments { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
    }
}