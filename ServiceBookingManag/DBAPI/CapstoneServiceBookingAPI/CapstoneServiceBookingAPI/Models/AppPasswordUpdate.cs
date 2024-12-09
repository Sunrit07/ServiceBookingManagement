using System.ComponentModel.DataAnnotations;

namespace CapstoneServiceBookingAPI.Models
{
    public class AppPasswordUpdate
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
