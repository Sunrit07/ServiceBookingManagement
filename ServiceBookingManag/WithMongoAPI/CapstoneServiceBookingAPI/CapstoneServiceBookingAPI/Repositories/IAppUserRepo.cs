using CapstoneServiceBookingAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Repositories
{
    public interface IAppUserRepo
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(string id);  // Change int to string for MongoDB ObjectId
        Task<AppUser> GetUserByEmailAndPasswordAsync(string email, string password);
        Task CreateUserAsync(AppUser user);
        Task UpdateUserAsync(AppUser user);
    }
}
