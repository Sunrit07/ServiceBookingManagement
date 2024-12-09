using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Repositories;
using CapstoneServiceBookingAPI.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Tests
{
    [TestFixture]
    public class AppProductServiceTests
    {
        private Mock<IAppProductRepo> _mockRepo;
        private IAppProductService _productService;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IAppProductRepo>();
            _productService = new AppProductService(_mockRepo.Object);
        }

        [Test]
        public async Task GetAllProductsAsync_ReturnsProductsForUser()
        {
            // Arrange
            var userId = 1;
            var products = new List<AppProduct>
            {
                new AppProduct { ProductId = 1, ProductName = "Product 1", UserId = userId },
                new AppProduct { ProductId = 2, ProductName = "Product 2", UserId = userId }
            };

            _mockRepo.Setup(repo => repo.GetAllProductsAsync(userId)).ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllProductsAsync(userId);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Product 1", result.First().ProductName);
        }

        [Test]
        public async Task GetProductByIdAsync_ReturnsCorrectProduct()
        {
            // Arrange
            var product = new AppProduct { ProductId = 1, ProductName = "Test Product", UserId = 1 };
            _mockRepo.Setup(repo => repo.GetProductByIdAsync(product.ProductId)).ReturnsAsync(product);

            // Act
            var result = await _productService.GetProductByIdAsync(product.ProductId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Product", result.ProductName);
        }

        [Test]
        public async Task CreateProductAsync_CallsRepositoryCreateProduct()
        {
            // Arrange
            var product = new AppProduct { ProductId = 1, ProductName = "New Product", UserId = 1 };

            // Act
            await _productService.CreateProductAsync(product);

            // Assert
            _mockRepo.Verify(repo => repo.CreateProductAsync(product), Times.Once);
        }

        [Test]
        public async Task UpdateProductAsync_CallsRepositoryUpdateProduct()
        {
            // Arrange
            var product = new AppProduct { ProductId = 1, ProductName = "Updated Product", UserId = 1 };

            // Act
            await _productService.UpdateProductAsync(product);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateProductAsync(product), Times.Once);
        }

        [Test]
        public async Task DeleteProductAsync_CallsRepositoryDeleteProduct()
        {
            // Arrange
            var productId = 1;

            // Act
            await _productService.DeleteProductAsync(productId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteProductAsync(productId), Times.Once);
        }
    }
}
