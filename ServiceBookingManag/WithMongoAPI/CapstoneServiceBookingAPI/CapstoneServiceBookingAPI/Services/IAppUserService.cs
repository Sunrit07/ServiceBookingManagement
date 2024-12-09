using CapstoneServiceBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Services
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(string id); // Changed int to string for MongoDB ObjectId
        Task CreateUserAsync(AppUser user);
        Task UpdateUserAsync(AppUser user);
        Task<(AppUser User, string Token)> AuthenticateUserAsync(string email, string password);
    }
}
