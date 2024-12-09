using System.ComponentModel.DataAnnotations;

namespace CapstoneServiceBookingAPI.Models
{
    public class AppProduct
    {
        [Key]
        public int ProductId { get; set; } // Auto-generated primary key
        [Required]
        public int UserId { get; set; } // Foreign key removed, just an int property
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Default value
    }
}
