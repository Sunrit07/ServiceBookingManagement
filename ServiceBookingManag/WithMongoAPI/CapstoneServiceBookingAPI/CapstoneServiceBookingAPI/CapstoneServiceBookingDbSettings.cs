namespace CapstoneServiceBookingAPI.Configuration
{
    public class CapstoneServiceBookingDbSettings
    {
        public string ConnectionString { get; set; } // Connection string for MongoDB
        public string DatabaseName { get; set; } // Name of the database
        public string AppUsersCollection { get; set; } // Collection for app users
        public string AppProductsCollection { get; set; } // Collection for app products
        public string AppServiceRequestsCollection { get; set; } // Collection for service requests
        public string AppServiceReqReportsCollection { get; set; } // Collection for service request reports
    }
}
