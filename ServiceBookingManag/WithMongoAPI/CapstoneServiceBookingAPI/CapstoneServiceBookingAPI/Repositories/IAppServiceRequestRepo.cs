using CapstoneServiceBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Repositories
{
    public interface IAppServiceRequestRepo
    {
        Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsAsync(); // Updated to include Async
        Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsByUserIdAsync(string userId); // Change int to string for MongoDB ObjectId
        Task<AppServiceReq> GetServiceRequestByIdAsync(string id); // Change int to string for MongoDB ObjectId
        Task CreateServiceRequestAsync(AppServiceReq serviceReq);
        Task UpdateServiceRequestAsync(AppServiceReq serviceReq);
        Task DeleteServiceRequestAsync(string id); // Change int to string for MongoDB ObjectId
    }
}
