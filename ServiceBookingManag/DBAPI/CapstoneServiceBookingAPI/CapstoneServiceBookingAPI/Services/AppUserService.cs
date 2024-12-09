using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CapstoneServiceBookingAPI.Services
{
    public class AppUserService:IAppUserService
    {
        private readonly IAppUserRepo _userRepository;
        private readonly AuthService _jwtService;

        public AppUserService(IAppUserRepo userRepository, AuthService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task CreateUserAsync(AppUser user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(AppUser user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task<(AppUser User, string Token)> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
            if (user == null)
            {
                return (null, null);
            }

            var token = _jwtService.GenerateJwtToken(user);

            return (user, token);
        }
    }
}
