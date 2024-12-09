using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CapstoneServiceBookingAPI.Models
{
    public class AppUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }  // Use string for MongoDB ObjectId

        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public string Password { get; set; }

        [BsonRequired]
        public string Email { get; set; }

        [BsonRequired]
        public string Mobile { get; set; }

        public string UserRole { get; set; } = "User"; // Default value

        public DateTime RegistrationDate { get; set; } = DateTime.Now; // Default value
    }
}
