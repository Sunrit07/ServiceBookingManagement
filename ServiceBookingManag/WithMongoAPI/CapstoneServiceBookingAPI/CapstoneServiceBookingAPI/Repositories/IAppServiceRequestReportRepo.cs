using CapstoneServiceBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Repositories
{
    public interface IAppServiceRequestReportRepo
    {
        Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsAsync();
        Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsByUserIdAsync(string userId); // Change int to string for MongoDB ObjectId
        Task<AppServiceReqReport> GetServiceReportByIdAsync(string id); // Change int to string for MongoDB ObjectId
        Task<AppServiceReqReport> GetServiceReportByUserIdAsync(string userId); // Change int to string for MongoDB ObjectId
        Task CreateServiceReportAsync(AppServiceReqReport report);
        Task UpdateServiceReportAsync(AppServiceReqReport report);
        Task DeleteServiceReportAsync(string id); // Change int to string for MongoDB ObjectId
    }
}
