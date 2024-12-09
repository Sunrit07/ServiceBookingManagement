using CapstoneServiceBookingAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Repositories
{
    public class AppServiceRequestReportRepo : IAppServiceRequestReportRepo
    {
        private readonly IMongoCollection<AppServiceReqReport> _reportCollection;

        public AppServiceRequestReportRepo(IMongoDatabase database)
        {
            _reportCollection = database.GetCollection<AppServiceReqReport>("AppServiceReqReports"); // Replace with your MongoDB collection name
        }

        // Get all service request reports
        public async Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsAsync()
        {
            return await _reportCollection.Find(_ => true).ToListAsync(); // Fetch all reports
        }

        public async Task<IEnumerable<AppServiceReqReport>> GetAllServiceReportsByUserIdAsync(string userId) // Changed int to string
        {
            return await _reportCollection.Find(x => x.UserId == userId).ToListAsync(); // Filter by UserId
        }

        // Get service request report by ID
        public async Task<AppServiceReqReport> GetServiceReportByIdAsync(string id) // Changed int to string
        {
            return await _reportCollection.Find(x => x.ReportId == id).FirstOrDefaultAsync(); // Assuming ReportId is a string
        }

        public async Task<AppServiceReqReport> GetServiceReportByUserIdAsync(string userId) // Changed int to string
        {
            return await _reportCollection.Find(x => x.UserId == userId).FirstOrDefaultAsync(); // Filter by UserId
        }

        // Create a new service request report
        public async Task CreateServiceReportAsync(AppServiceReqReport report)
        {
            await _reportCollection.InsertOneAsync(report);
        }

        // Update an existing service request report
        public async Task UpdateServiceReportAsync(AppServiceReqReport report)
        {
            await _reportCollection.ReplaceOneAsync(x => x.ReportId == report.ReportId, report); // Assuming ReportId is a string
        }

        // Delete a service request report by ID
        public async Task DeleteServiceReportAsync(string id) // Changed int to string
        {
            var result = await _reportCollection.DeleteOneAsync(x => x.ReportId == id); // Assuming ReportId is a string
            if (result.DeletedCount == 0)
            {
                throw new KeyNotFoundException($"Service report with ID {id} not found.");
            }
        }
    }
}
