using CapstoneServiceBookingAPI.Data;
using CapstoneServiceBookingAPI.Models;
using CapstoneServiceBookingAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace CapstoneServiceBookingAPI.Repositories
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly ServiceBookingManagementDbContext _context;
        private readonly AppPasswordService _passwordService;

        public AppUserRepo(ServiceBookingManagementDbContext context, AppPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _context.AppUsers.ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.AppUsers.FindAsync(id);
        }

        public async Task<AppUser> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var u = await _context.AppUsers.FirstOrDefaultAsync(v => v.Email == email);
            if (u == null || !_passwordService.VerifyPassword(password, u.Password))
                return null;
            return u;
        }

        public async Task CreateUserAsync(AppUser user)
        {
            // Create new user
            var u = new AppUser
            {
                Name = user.Name,
                Password = _passwordService.HashPassword(user.Password),
                Email = user.Email,
                Mobile = user.Mobile,
                UserRole = user.UserRole,
                RegistrationDate = user.RegistrationDate
            };
            await _context.AppUsers.AddAsync(u);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(AppUser user)
        {
            _context.AppUsers.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
