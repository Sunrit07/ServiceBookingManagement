using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Services
{
    public class AppServiceRequestService : IAppServiceRequestService
    {
        private readonly IAppServiceRequestRepo _serviceReqRepository;

        public AppServiceRequestService(IAppServiceRequestRepo serviceReqRepository)
        {
            _serviceReqRepository = serviceReqRepository;
        }

        public async Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsAsync() // Updated method signature
        {
            return await _serviceReqRepository.GetAllServiceRequestsAsync();
        }

        public async Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsByUserIdAsync(string userId) // Changed int to string
        {
            return await _serviceReqRepository.GetAllServiceRequestsByUserIdAsync(userId);
        }

        public async Task<AppServiceReq> GetServiceRequestByIdAsync(string id) // Changed int to string
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

        public async Task DeleteServiceRequestAsync(string id) // Changed int to string
        {
            await _serviceReqRepository.DeleteServiceRequestAsync(id);
        }
    }
}
