using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CapstoneServiceBookingAPI.Models
{
    public class AppServiceReq
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SerReqId { get; set; } // Use string for MongoDB ObjectId

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; } // Change to string for MongoDB ObjectId

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } // Change to string for MongoDB ObjectId

        public DateTime ReqDate { get; set; } = DateTime.Now; // Default value

        [Required]
        public string Problem { get; set; }

        [Required]
        public string Description { get; set; }

        public string Status { get; set; } = "pending"; // Default value
    }
}
