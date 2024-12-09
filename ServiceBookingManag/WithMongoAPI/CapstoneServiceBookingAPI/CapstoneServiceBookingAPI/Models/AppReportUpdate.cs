using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CapstoneServiceBookingAPI.Models
{
    public class AppReportUpdate
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string SerReqId { get; set; } // Use string for MongoDB ObjectId

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } // Change to string for MongoDB ObjectId

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
