using CapstoneServiceBookingAPI.Data;
using CapstoneServiceBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneServiceBookingAPI.Repositories
{
    public class AppServiceRequestReportRepo : IAppServiceRequestReportRepo
    {
        private readonly ServiceBookingManagementDbContext _context;

        public AppServiceRequestReportRepo(ServiceBookingManagementDbContext context)
        {
            _context = context;
        }

        // Get all service request reports
        public async Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsAsync()
        {
            return await _context.AppServiceReqReports.ToListAsync();
        }

        public async Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsByUserIdAsync(int id)
        {
            return await _context.AppServiceReqReports.Where(x => x.UserId == id).ToListAsync();
        }

        // Get service request report by ID
        public async Task<AppServiceReqReport> GetServiceReportByIdAsync(int id)
        {
            return await _context.AppServiceReqReports.FindAsync(id);
        }

        public async Task<AppServiceReqReport> GetServiceReportByUserIdAsync(int uid)
        {
            return await _context.AppServiceReqReports.FirstOrDefaultAsync(x => x.UserId == uid);
        }

        // Create a new service request report
        public async Task CreateServiceReportAsync(AppServiceReqReport report)
        {
            await _context.AppServiceReqReports.AddAsync(report);
            await _context.SaveChangesAsync();
        }

        // Update an existing service request report
        public async Task UpdateServiceReportAsync(AppServiceReqReport report)
        {
            _context.AppServiceReqReports.Update(report);
            await _context.SaveChangesAsync();
        }

        // Delete a service request report by ID
        public async Task DeleteServiceReportAsync(int id)
        {
            var report = await _context.AppServiceReqReports.FindAsync(id);
            if (report != null)
            {
                _context.AppServiceReqReports.Remove(report);
                await _context.SaveChangesAsync();
            }
        }
    }
}
