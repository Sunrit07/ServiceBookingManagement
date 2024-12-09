using CapstoneServiceBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneServiceBookingAPI.Data
{
    public class ServiceBookingManagementDbContext : DbContext
    {
        public ServiceBookingManagementDbContext(DbContextOptions<ServiceBookingManagementDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-O40H1NOE\\SQLEXPRESS;Database=CapstoneServiceBookingDB;Trusted_Connection=True;");
            }

        }



        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppProduct> AppProducts { get; set; }
        public DbSet<AppServiceReq> AppServiceRequests { get; set; }
        public DbSet<AppServiceReqReport> AppServiceReqReports { get; set; }
    }
}
