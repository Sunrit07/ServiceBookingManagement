using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CapstoneServiceBookingAPI.Models
{
    public class AppProduct
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; } // Use string for MongoDB ObjectId

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } // Change to string for MongoDB ObjectId

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
