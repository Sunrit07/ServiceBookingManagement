using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Repositories;

namespace CapstoneServiceBookingAPI.Services
{
    public class AppServiceRequestReportService : IAppServiceRequestReportService
    {
        private readonly IAppServiceRequestReportRepo _serviceReqReportRepo;

        public AppServiceRequestReportService(IAppServiceRequestReportRepo serviceReqReportRepo)
        {
            _serviceReqReportRepo = serviceReqReportRepo;
        }

        public async Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsAsync()
        {
            return await _serviceReqReportRepo.GetAllServiceReportsAsync();
        }

        public async Task<AppServiceReqReport> GetServiceReportByIdAsync(string id) // Changed int to string for MongoDB
        {
            return await _serviceReqReportRepo.GetServiceReportByIdAsync(id);
        }

        public async Task CreateServiceReportAsync(AppServiceReqReport report)
        {
            await _serviceReqReportRepo.CreateServiceReportAsync(report);
        }

        public async Task UpdateServiceReportAsync(AppServiceReqReport report)
        {
            await _serviceReqReportRepo.UpdateServiceReportAsync(report);
        }

        public async Task DeleteServiceReportAsync(string id) // Changed int to string for MongoDB
        {
            await _serviceReqReportRepo.DeleteServiceReportAsync(id);
        }

        public async Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsByUserIdAsync(string userId) // Changed int to string for MongoDB
        {
            return await _serviceReqReportRepo.GetAllServiceReportsByUserIdAsync(userId);
        }
    }
}
