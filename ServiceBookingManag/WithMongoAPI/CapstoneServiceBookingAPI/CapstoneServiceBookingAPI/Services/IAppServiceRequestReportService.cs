using CapstoneServiceBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Services
{
    public interface IAppServiceRequestReportService
    {
        Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsAsync();
        Task<AppServiceReqReport> GetServiceReportByIdAsync(string id); // Changed int to string
        Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsByUserIdAsync(string userId); // Changed int to string
        Task CreateServiceReportAsync(AppServiceReqReport report);
        Task UpdateServiceReportAsync(AppServiceReqReport report);
        Task DeleteServiceReportAsync(string id); // Changed int to string
    }
}
