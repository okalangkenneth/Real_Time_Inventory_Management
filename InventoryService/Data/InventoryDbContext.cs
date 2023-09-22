using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Home Appliances" }
            );

            // Seed Suppliers
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1, Name = "Supplier A" },
                new Supplier { SupplierId = 2, Name = "Supplier B" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop", Quantity = 10, CategoryId = 1, SupplierId = 1 },
                new Product { ProductId = 2, Name = "Phone", Quantity = 20, CategoryId = 1, SupplierId = 2 },
                new Product { ProductId = 3, Name = "TV", Quantity = 5, CategoryId = 2, SupplierId = 1 }
            );
        }




    }
}
