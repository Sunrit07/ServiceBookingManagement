using CapstoneServiceBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Services
{
    public interface IAppServiceRequestService
    {
        Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsAsync(); // Updated method signature
        Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsByUserIdAsync(string userId); // Changed int to string
        Task<AppServiceReq> GetServiceRequestByIdAsync(string id); // Changed int to string
        Task CreateServiceRequestAsync(AppServiceReq serviceReq);
        Task UpdateServiceRequestAsync(AppServiceReq serviceReq);
        Task DeleteServiceRequestAsync(string id); // Changed int to string
    }
}
