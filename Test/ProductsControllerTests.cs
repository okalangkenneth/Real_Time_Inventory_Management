using InventoryService.Controllers;
using InventoryService.Data;
using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class ProductsControllerTests
    {
        private readonly ProductsController _controller;
        private readonly InventoryDbContext _context;

        public ProductsControllerTests()
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new InventoryDbContext(options);
            _controller = new ProductsController(_context);
        }

        [Fact]
        public async Task GetProducts_ReturnsAllProducts()
        {
            // Arrange
            var product1 = new Product { ProductId = 1, Name = "Laptop", Quantity = 10 };
            var product2 = new Product { ProductId = 2, Name = "Phone", Quantity = 20 };
            _context.Products.AddRange(product1, product2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.GetProducts();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Product>>>(result);
            var returnValue = Assert.IsType<List<Product>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
        [Fact]
        public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Act
            var result = await _controller.GetProduct(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }


        [Fact]
        public async Task AddProduct_ReturnsCreatedProduct()
        {
            // Arrange
            var product = new Product { ProductId = 1, Name = "Laptop", Quantity = 10 };

            // Act
            var result = await _controller.PostProduct(product);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Product>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var returnValue = Assert.IsType<Product>(createdAtActionResult.Value);
            Assert.Equal(product.Name, returnValue.Name);
        }




        // Add more tests for other actions like GetProduct, PostProduct, etc.
    }
}
