using CapstoneServiceBookingAPI.Data;
using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Tests
{
    [TestFixture]
    public class AppProductRepoTests
    {
        private ServiceBookingManagementDbContext _context;
        private AppProductRepo _repo;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ServiceBookingManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new ServiceBookingManagementDbContext(options);
            _repo = new AppProductRepo(_context);
        }

        [Test]
        public async Task CreateProductAsync_ShouldAddProduct()
        {
            var product = new AppProduct { ProductName = "Test Product", Make = "Test Make", Model = "Test Model", Cost = 100, UserId = 1 };

            await _repo.CreateProductAsync(product);
            var result = await _repo.GetAllProductsAsync(1);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Test Product", result.First().ProductName);
        }

        [Test]
        public async Task GetAllProductsAsync_ShouldReturnProductsForUser()
        {
            var product1 = new AppProduct { ProductName = "Product 1", Make = "Make 1", Model = "Model 1", Cost = 50, UserId = 1 };
            var product2 = new AppProduct { ProductName = "Product 2", Make = "Make 2", Model = "Model 2", Cost = 150, UserId = 2 };
            await _repo.CreateProductAsync(product1);
            await _repo.CreateProductAsync(product2);

            var result = await _repo.GetAllProductsAsync(1);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Product 1", result.First().ProductName);
        }

        [Test]
        public async Task GetProductByIdAsync_ShouldReturnProduct()
        {
            var product = new AppProduct { ProductName = "Test Product", Make = "Test Make", Model = "Test Model", Cost = 100, UserId = 1 };
            await _repo.CreateProductAsync(product);

            var result = await _repo.GetProductByIdAsync(product.ProductId);

            Assert.IsNotNull(result);
            Assert.AreEqual("Test Product", result.ProductName);
        }

        [Test]
        public async Task UpdateProductAsync_ShouldUpdateProduct()
        {
            var product = new AppProduct { ProductName = "Old Product", Make = "Old Make", Model = "Old Model", Cost = 100, UserId = 1 };
            await _repo.CreateProductAsync(product);

            product.ProductName = "Updated Product";
            await _repo.UpdateProductAsync(product);

            var result = await _repo.GetProductByIdAsync(product.ProductId);
            Assert.AreEqual("Updated Product", result.ProductName);
        }

        [Test]
        public async Task DeleteProductAsync_ShouldRemoveProduct()
        {
            var product = new AppProduct { ProductName = "Test Product", Make = "Test Make", Model = "Test Model", Cost = 100, UserId = 1 };
            await _repo.CreateProductAsync(product);

            await _repo.DeleteProductAsync(product.ProductId);
            var result = await _repo.GetProductByIdAsync(product.ProductId);

            Assert.IsNull(result);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the in-memory database after each test
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
