using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneServiceBookingAPI.Services; // Ensure this is the correct namespace for your services
using Microsoft.AspNetCore.Authorization;
using CapstoneServiceBookingAPI.Models;
using MongoDB.Bson; // Include the MongoDB Bson namespace
using System.Threading.Tasks;

namespace CapstoneServiceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppServiceController : ControllerBase
    {
        private readonly IAppServiceRequestService _serviceRequestService;
        private readonly IAppServiceRequestReportService _reportService;

        public AppServiceController(IAppServiceRequestService serviceRequestService, IAppServiceRequestReportService reportService)
        {
            _serviceRequestService = serviceRequestService;
            _reportService = reportService;
        }

        [HttpGet("getservicerequestsAdminOnly")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllServiceRequests()
        {
            var serviceRequests = await _serviceRequestService.GetAllServiceRequestsAsync(); // Correct method name
            return Ok(new { status = "success", msg = "Service requests retrieved", serviceRequests });
        }

        [HttpGet("getServiceRequestsUserOnly/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllServiceRequests(string id)
        {
            // Remove the ObjectId conversion since you are passing the string ID directly
            var serviceRequests = await _serviceRequestService.GetAllServiceRequestsByUserIdAsync(id); // Correct method
            return Ok(new { status = "success", msg = "Service requests retrieved", serviceRequests });
        }

        [HttpGet("getServiceRequest/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetServiceRequestById(string id)
        {
            var serviceRequest = await _serviceRequestService.GetServiceRequestByIdAsync(id); // Pass string id directly
            if (serviceRequest == null)
                return NotFound(new { status = "error", msg = "Service request not found" });

            return Ok(new { status = "success", msg = "Service request retrieved", payload = serviceRequest });
        }

        [HttpPost("createRequestUserOnly")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateServiceRequest([FromBody] AppServiceReq serviceReq)
        {
            await _serviceRequestService.CreateServiceRequestAsync(serviceReq);
            return Ok(new { status = "success", msg = "Service request created", payload = serviceReq });
        }

        [HttpPut("updateRequestUserOnly")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> UpdateServiceRequest([FromBody] AppServiceReq serviceReq)
        {
            await _serviceRequestService.UpdateServiceRequestAsync(serviceReq);
            return Ok(new { status = "success", msg = "Service request updated", payload = serviceReq });
        }

        [HttpDelete("deleteRequestUser/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteServiceRequest(string id)
        {
            await _serviceRequestService.DeleteServiceRequestAsync(id); // Pass string id directly
            return Ok(new { status = "success", msg = "Service request deleted" });
        }

        [HttpGet("getAllReportAdminOnly")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllServiceReports()
        {
            var reports = await _reportService.GetAllServiceReportsAsync();
            return Ok(new { status = "success", msg = "Service reports retrieved", payload = reports });
        }

        [HttpGet("getReportsUserOnly/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllServiceReportsByUserId(string id)
        {
            var report = await _reportService.GetAllServiceReportsByUserIdAsync(id); // Directly use the string ID
            if (report == null)
                return NotFound(new { status = "error", msg = "Service report not found" });

            return Ok(new { status = "success", msg = "Service report retrieved", payload = report });
        }

        [HttpGet("getReportAdminAndUser/{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetServiceReportById(string id)
        {
            var report = await _reportService.GetServiceReportByIdAsync(id); // Directly use the string ID
            if (report == null)
                return NotFound(new { status = "error", msg = "Service report not found" });

            return Ok(new { status = "success", msg = "Service report retrieved", payload = report });
        }
    }
}
