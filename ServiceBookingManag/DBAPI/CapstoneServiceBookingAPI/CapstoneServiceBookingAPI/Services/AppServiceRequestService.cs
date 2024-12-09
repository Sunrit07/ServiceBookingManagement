using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Repositories;

namespace CapstoneServiceBookingAPI.Services
{
    public class AppServiceRequestService : IAppServiceRequestService
    {
        private readonly IAppServiceRequestRepo _serviceReqRepository;

        public AppServiceRequestService(IAppServiceRequestRepo serviceReqRepository)
        {
            _serviceReqRepository = serviceReqRepository;
        }

        public async Task<IEnumerable<AppServiceReq>> GetAllServiceRequests()
        {
            return await _serviceReqRepository.GetAllServiceRequests();
        }
        public async Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsAsync(int id)
        {
            return await _serviceReqRepository.GetAllServiceRequestsAsync(id);
        }

        public async Task<AppServiceReq> GetServiceRequestByIdAsync(int id)
        {
            return await _serviceReqRepository.GetServiceRequestByIdAsync(id);
        }

        public async Task CreateServiceRequestAsync(AppServiceReq serviceReq)
        {
            await _serviceReqRepository.CreateServiceRequestAsync(serviceReq);
        }

        public async Task UpdateServiceRequestAsync(AppServiceReq serviceReq)
        {
            await _serviceReqRepository.UpdateServiceRequestAsync(serviceReq);
        }

        public async Task DeleteServiceRequestAsync(int id)
        {
            await _serviceReqRepository.DeleteServiceRequestAsync(id);
        }
    }
}
