using CapstoneServiceBookingAPI.Models;

namespace CapstoneServiceBookingAPI.Repositories
{
    public interface IAppServiceRequestReportRepo
    {
        Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsAsync();
        Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsByUserIdAsync(int id);
        Task<AppServiceReqReport> GetServiceReportByIdAsync(int id);
        Task<AppServiceReqReport> GetServiceReportByUserIdAsync(int id);
        Task CreateServiceReportAsync(AppServiceReqReport report);
        Task UpdateServiceReportAsync(AppServiceReqReport report);
        Task DeleteServiceReportAsync(int id);
    }
}
