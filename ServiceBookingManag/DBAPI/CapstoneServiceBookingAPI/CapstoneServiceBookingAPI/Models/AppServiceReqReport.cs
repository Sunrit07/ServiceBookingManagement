using System.ComponentModel.DataAnnotations;

namespace CapstoneServiceBookingAPI.Models
{
    public class AppServiceReqReport
    {
        [Key]
        public int ReportId { get; set; } // Auto-generated primary key
        [Required]
        public int SerReqId { get; set; } // Foreign key removed, just an int property
        [Required]
        public int UserId { get; set; } // Foreign key removed, just an int property
        public DateTime ReportDate { get; set; } = DateTime.Now; // Default value
        [Required]
        public string ServiceType { get; set; } // general, repair, support
        [Required]
        public string ActionTaken { get; set; }
        [Required]
        public string DiagnosisDetails { get; set; }
        [Required]
        public bool IsPaid { get; set; }
        [Required]
        public decimal VisitFees { get; set; }
        [Required]
        public string RepairDetails { get; set; }
    }
}
