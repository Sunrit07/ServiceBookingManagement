using CapstoneServiceBookingAPI.Models;

namespace CapstoneServiceBookingAPI.Services
{
    public interface IAppServiceRequestReportService
    {
        Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsAsync();
        Task<AppServiceReqReport> GetServiceReportByIdAsync(int id);
        Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsByUserIdAsync(int id);
        Task CreateServiceReportAsync(AppServiceReqReport report);
        Task UpdateServiceReportAsync(AppServiceReqReport report);
        Task DeleteServiceReportAsync(int id);
    }
}
