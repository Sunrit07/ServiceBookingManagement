using CapstoneServiceBookingAPI.Models;

namespace CapstoneServiceBookingAPI.Services
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task CreateUserAsync(AppUser user);
        Task UpdateUserAsync(AppUser user);
        Task<(AppUser User, string Token)> AuthenticateUserAsync(string email, string password);
    }
}
