using CapstoneServiceBookingAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Repositories
{
    public class AppServiceRequestRepo : IAppServiceRequestRepo
    {
        private readonly IMongoCollection<AppServiceReq> _serviceRequestCollection;

        public AppServiceRequestRepo(IMongoDatabase database)
        {
            _serviceRequestCollection = database.GetCollection<AppServiceReq>("AppServiceRequests"); // Replace with your MongoDB collection name
        }

        // Get all service requests for a specific user
        public async Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsByUserIdAsync(string userId) // Changed int to string
        {
            return await _serviceRequestCollection.Find(x => x.UserId == userId).ToListAsync(); // Fetch requests by user ID
        }

        // Get all service requests
        public async Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsAsync() // Updated method name to match the interface
        {
            return await _serviceRequestCollection.Find(_ => true).ToListAsync(); // Fetch all documents
        }

        // Get service request by ID
        public async Task<AppServiceReq> GetServiceRequestByIdAsync(string id) // Changed int to string
        {
            return await _serviceRequestCollection.Find(x => x.SerReqId == id).FirstOrDefaultAsync(); // Assuming SerReqId is a string
        }

        // Create a new service request
        public async Task CreateServiceRequestAsync(AppServiceReq serviceReq)
        {
            await _serviceRequestCollection.InsertOneAsync(serviceReq);
        }

        // Update an existing service request
        public async Task UpdateServiceRequestAsync(AppServiceReq serviceReq)
        {
            await _serviceRequestCollection.ReplaceOneAsync(x => x.SerReqId == serviceReq.SerReqId, serviceReq); // Assuming SerReqId is a string
        }

        // Delete a service request by ID
        public async Task DeleteServiceRequestAsync(string id) // Changed int to string
        {
            var result = await _serviceRequestCollection.DeleteOneAsync(x => x.SerReqId == id); // Assuming SerReqId is a string
            if (result.DeletedCount == 0)
            {
                throw new KeyNotFoundException($"Service request with ID {id} not found.");
            }
        }
    }
}
