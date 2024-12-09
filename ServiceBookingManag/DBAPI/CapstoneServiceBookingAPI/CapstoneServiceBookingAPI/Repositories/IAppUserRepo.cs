using CapstoneServiceBookingAPI.Models;

namespace CapstoneServiceBookingAPI.Repositories
{
    public interface IAppUserRepo
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByEmailAndPasswordAsync(string email, string password);
        Task CreateUserAsync(AppUser user);
        Task UpdateUserAsync(AppUser user);
    }
}
