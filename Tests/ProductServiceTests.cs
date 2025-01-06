using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Services;
namespace Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task AddProductAsync_ShouldAddProduct()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            var service = new ProductService(mockRepo.Object);

            var product = new Product
            {
                Name = "Test Product",
                Price = 10,
                Stock = 100
            };

            // Act
            await service.AddProductAsync(product);

            // Assert
            mockRepo.Verify(r => r.AddAsync(product), Times.Once);
        }
    }
}
