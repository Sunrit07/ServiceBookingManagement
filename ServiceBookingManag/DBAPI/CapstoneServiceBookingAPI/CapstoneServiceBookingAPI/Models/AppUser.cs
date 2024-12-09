using System.ComponentModel.DataAnnotations;

namespace CapstoneServiceBookingAPI.Models
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }  // Auto-generated primary key
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string UserRole { get; set; } = "User"; // Default value
        public DateTime RegistrationDate { get; set; } = DateTime.Now; // Default value
    }
}
