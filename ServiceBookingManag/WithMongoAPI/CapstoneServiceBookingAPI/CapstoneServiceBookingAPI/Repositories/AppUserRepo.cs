using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Repositories
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly AppPasswordService _passwordService;

        public AppUserRepo(IMongoDatabase database, AppPasswordService passwordService)
        {
            _userCollection = database.GetCollection<AppUser>("AppUsers"); // Replace with your MongoDB collection name
            _passwordService = passwordService;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _userCollection.Find(user => true).ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await _userCollection.Find(user => user.UserId == id).FirstOrDefaultAsync(); // Assuming UserId is a string
        }

        public async Task<AppUser> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var user = await _userCollection.Find(u => u.Email == email).FirstOrDefaultAsync();
            if (user == null || !_passwordService.VerifyPassword(password, user.Password))
                return null;
            return user;
        }

        public async Task CreateUserAsync(AppUser user)
        {
            // Create new user
            var newUser = new AppUser
            {
                Name = user.Name,
                Password = _passwordService.HashPassword(user.Password),
                Email = user.Email,
                Mobile = user.Mobile,
                UserRole = user.UserRole,
                RegistrationDate = user.RegistrationDate
            };
            await _userCollection.InsertOneAsync(newUser);
        }

        public async Task UpdateUserAsync(AppUser user)
        {
            await _userCollection.ReplaceOneAsync(u => u.UserId == user.UserId, user); // Assuming UserId is a string
        }
    }
}
