using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneServiceBookingAPI.Services; // Updated namespace
using Microsoft.AspNetCore.Authorization;
using CapstoneServiceBookingAPI.Models;
using MongoDB.Bson; // Include the MongoDB Bson namespace

namespace CapstoneServiceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _userService;

        public AppUserController(IAppUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] AppUser user)
        {
            await _userService.CreateUserAsync(user);
            return Ok(new { status = "success", msg = "User created", payload = user });
        }

        [HttpPut("update")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] AppUser user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok(new { status = "success", msg = "User updated", payload = user });
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(new { status = "success", msg = "Users retrieved", payload = users });
        }

        [HttpGet("user/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserById(string id)
        {
            // Check if the id is a valid ObjectId
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return BadRequest(new { status = "error", msg = "Invalid user ID format" });
            }

            // Retrieve the user by ID using string representation
            var user = await _userService.GetUserByIdAsync(id); // Use the string id directly
            if (user == null)
                return NotFound(new { status = "error", msg = "User not found" });

            return Ok(new { status = "success", msg = "User retrieved", payload = user });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AppUserLogin login)
        {
            var email = login.Email;
            var password = login.Password;
            var (user, token) = await _userService.AuthenticateUserAsync(email, password);
            if (user == null)
                return Unauthorized(new { status = "error", msg = "Invalid credentials" });

            // Return the user ID (now correctly referencing UserId) and role along with the token
            return Ok(new { status = "success", msg = "Login successful", jwttoken = token, userid = user.UserId, role = user.UserRole });
        }

    }
}
