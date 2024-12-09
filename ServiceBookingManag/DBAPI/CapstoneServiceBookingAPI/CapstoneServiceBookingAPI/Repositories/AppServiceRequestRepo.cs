using CapstoneServiceBookingAPI.Data;
using CapstoneServiceBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneServiceBookingAPI.Repositories
{
    public class AppServiceRequestRepo : IAppServiceRequestRepo
    {
        private readonly ServiceBookingManagementDbContext _context;

        public AppServiceRequestRepo(ServiceBookingManagementDbContext context)
        {
            _context = context;
        }

        // Get all service requests
        public async Task<IEnumerable<AppServiceReq>> GetAllServiceRequestsAsync(int id)
        {
            return await _context.AppServiceRequests.Where(x => x.UserId == id).ToListAsync();
        }

        public async Task<IEnumerable<AppServiceReq>> GetAllServiceRequests()
        {
            return await _context.AppServiceRequests.ToListAsync();
        }

        // Get service request by ID
        public async Task<AppServiceReq> GetServiceRequestByIdAsync(int id)
        {
            return await _context.AppServiceRequests.FindAsync(id);
        }

        // Create a new service request
        public async Task CreateServiceRequestAsync(AppServiceReq serviceReq)
        {
            await _context.AppServiceRequests.AddAsync(serviceReq);
            await _context.SaveChangesAsync();
        }

        // Update an existing service request
        public async Task UpdateServiceRequestAsync(AppServiceReq serviceReq)
        {
            _context.AppServiceRequests.Update(serviceReq);
            await _context.SaveChangesAsync();
        }

        // Delete a service request by ID
        public async Task DeleteServiceRequestAsync(int id)
        {
            var serviceReq = await _context.AppServiceRequests.FindAsync(id);
            if (serviceReq != null)
            {
                _context.AppServiceRequests.Remove(serviceReq);
                await _context.SaveChangesAsync();
            }
        }
    }
}
