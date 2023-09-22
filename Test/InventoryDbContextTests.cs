using InventoryService.Data;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Test
{
    public class InventoryDbContextTests
    {
        [Fact]
        public void Should_Add_New_Product()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseInMemoryDatabase(databaseName: "Add_New_Product")
                .Options;

            var newProduct = new Product { ProductId = 1, Name = "Laptop", Quantity = 10 };

            // Act
            using (var context = new InventoryDbContext(options))
            {
                context.Products.Add(newProduct);
                context.SaveChanges();
            }

            // Assert
            using (var context = new InventoryDbContext(options))
            {
                var foundProduct = context.Products.Find(1);
                Assert.NotNull(foundProduct);
                Assert.Equal("Laptop", foundProduct.Name);
            }
        }

        [Fact]
        public void Should_Update_Product_Quantity()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseInMemoryDatabase(databaseName: "Update_Product_Quantity")
                .Options;

            var existingProduct = new Product { ProductId = 1, Name = "Laptop", Quantity = 10 };

            using (var context = new InventoryDbContext(options))
            {
                context.Products.Add(existingProduct);
                context.SaveChanges();
            }

            // Act
            using (var context = new InventoryDbContext(options))
            {
                var productToUpdate = context.Products.Find(1);
                productToUpdate.Quantity = 20;
                context.SaveChanges();
            }

            // Assert
            using (var context = new InventoryDbContext(options))
            {
                var updatedProduct = context.Products.Find(1);
                Assert.NotNull(updatedProduct);
                Assert.Equal(20, updatedProduct.Quantity);
            }
        }
    }
}
