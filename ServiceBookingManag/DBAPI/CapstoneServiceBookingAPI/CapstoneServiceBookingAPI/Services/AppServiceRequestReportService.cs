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

        public async Task<AppServiceReqReport> GetServiceReportByIdAsync(int id)
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

        public async Task DeleteServiceReportAsync(int id)
        {
            await _serviceReqReportRepo.DeleteServiceReportAsync(id);
        }

        public async Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsByUserIdAsync(int id)
        {
            return await _serviceReqReportRepo.GetAllServiceReportsByUserIdAsync(id);
        }
    }
}
