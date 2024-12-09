using CapstoneServiceBookingAPI.Models;

namespace CapstoneServiceBookingAPI.Services
{
    public interface IAppServiceRequestService
    {
        Task<IEnumerable<AppServiceReq>> GetAllServiceRequests();
        Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsAsync(int id);
        Task<AppServiceReq> GetServiceRequestByIdAsync(int id);
        Task CreateServiceRequestAsync(AppServiceReq serviceReq);
        Task UpdateServiceRequestAsync(AppServiceReq serviceReq);
        Task DeleteServiceRequestAsync(int id);
    }
}
