using CapstoneServiceBookingAPI.Data;
using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Tests
{
    [TestFixture]
    public class AppServiceRequestRepoTests
    {
        private AppServiceRequestRepo _repo;
        private ServiceBookingManagementDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ServiceBookingManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ServiceBookingManagementDbContext(options);
            _repo = new AppServiceRequestRepo(_context);
        }

        [TearDown]
        public void Teardown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task GetAllServiceRequestsAsync_ReturnsCorrectServiceRequestsForUser()
        {
            // Arrange
            var userId = 1;
            _context.AppServiceRequests.AddRange(
                new AppServiceReq { SerReqId = 1, UserId = userId, ProductId = 1, Problem = "Problem 1", Description = "Desc 1" },
                new AppServiceReq { SerReqId = 2, UserId = userId, ProductId = 2, Problem = "Problem 2", Description = "Desc 2" },
                new AppServiceReq { SerReqId = 3, UserId = 2, ProductId = 3, Problem = "Problem 3", Description = "Desc 3" } // different user
            );
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetAllServiceRequestsAsync(userId);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetServiceRequestByIdAsync_ReturnsCorrectServiceRequest()
        {
            // Arrange
            var serviceReq = new AppServiceReq { SerReqId = 1, UserId = 1, ProductId = 1, Problem = "Problem", Description = "Desc" };
            _context.AppServiceRequests.Add(serviceReq);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repo.GetServiceRequestByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(serviceReq.SerReqId, result.SerReqId);
        }

        [Test]
        public async Task CreateServiceRequestAsync_AddsServiceRequest()
        {
            // Arrange
            var serviceReq = new AppServiceReq { SerReqId = 1, UserId = 1, ProductId = 1, Problem = "Problem", Description = "Desc" };

            // Act
            await _repo.CreateServiceRequestAsync(serviceReq);

            // Assert
            var result = await _context.AppServiceRequests.FirstOrDefaultAsync(x => x.SerReqId == 1);
            Assert.IsNotNull(result);
            Assert.AreEqual(serviceReq.Problem, result.Problem);
        }

        [Test]
        public async Task UpdateServiceRequestAsync_UpdatesServiceRequest()
        {
            // Arrange
            var serviceReq = new AppServiceReq { SerReqId = 1, UserId = 1, ProductId = 1, Problem = "Initial Problem", Description = "Initial Desc" };
            _context.AppServiceRequests.Add(serviceReq);
            await _context.SaveChangesAsync();

            // Act
            serviceReq.Problem = "Updated Problem";
            await _repo.UpdateServiceRequestAsync(serviceReq);

            // Assert
            var result = await _context.AppServiceRequests.FirstOrDefaultAsync(x => x.SerReqId == 1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Problem", result.Problem);
        }

        [Test]
        public async Task DeleteServiceRequestAsync_RemovesServiceRequest()
        {
            // Arrange
            var serviceReq = new AppServiceReq { SerReqId = 1, UserId = 1, ProductId = 1, Problem = "Problem", Description = "Desc" };
            _context.AppServiceRequests.Add(serviceReq);
            await _context.SaveChangesAsync();

            // Act
            await _repo.DeleteServiceRequestAsync(1);

            // Assert
            var result = await _context.AppServiceRequests.FindAsync(1);
            Assert.IsNull(result);
        }
    }
}
