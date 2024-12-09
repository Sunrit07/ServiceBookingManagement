using System.ComponentModel.DataAnnotations;

namespace CapstoneServiceBookingAPI.Models
{
    public class AppServiceReq
    {
        [Key]
        public int SerReqId { get; set; } // Auto-generated primary key
        [Required]
        public int ProductId { get; set; } // Foreign key removed, just an int property
        [Required]
        public int UserId { get; set; } // Foreign key removed, just an int property
        public DateTime ReqDate { get; set; } = DateTime.Now; // Default value
        [Required]
        public string Problem { get; set; }
        [Required]
        public string Description { get; set; }
        public string Status { get; set; } = "pending"; // Default value
    }
}
