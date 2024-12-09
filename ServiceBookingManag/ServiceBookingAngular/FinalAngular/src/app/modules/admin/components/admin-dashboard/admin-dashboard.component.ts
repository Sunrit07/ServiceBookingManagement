import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ServiceBookingService } from 'src/app/Services/service-booking.service'; // Service to interact with API
import { FormBuilder, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit{
  // serviceRequests: any[] = [];  // Store fetched service requests
  // statusOptions: string[] = ['pending', 'assigned', 'resolved'];  // Status options for the dropdown
  // statusForm: FormGroup;

  // constructor(private serviceRequestService: ServiceBookingService, private fb: FormBuilder) {
  //   this.statusForm = this.fb.group({
  //     status: ['']  // Form group for status change
  //   });
  // }

  // ngOnInit(): void {
  //   this.getServiceRequests();
  // }

  // // Fetch all service requests
  // getServiceRequests(): void {
  //   this.serviceRequestService.getAllServiceRequests().subscribe(
  //     (data: any) => {
  //       this.serviceRequests = data.serviceRequests;
  //     },
  //     (error: any) => {
  //       console.error('Error fetching service requests:', error);
  //     }
  //   );
  // }

  // // Update status of a request
  // updateStatus(serviceRequest: any, newStatus: string): void {
  //   const updatedRequest = {
  //     ...serviceRequest,  // Spread the existing request details
  //     status: newStatus   // Update status with new value from dropdown
  //   };

  //   this.serviceRequestService.updateServiceRequest(updatedRequest).subscribe(
  //     (response: any) => {
  //       console.log('Status updated:', response);
  //       this.getServiceRequests();  // Refresh the request list after update
  //     },
  //     (error: any) => {
  //       console.error('Error updating status:', error);
  //     }
  //   );
  // }
  serviceRequests: any[] = [];  // List of service requests
  statusOptions: string[] = ['Pending', 'Assigned', 'Resolved'];  // Status options for dropdown
  displayedColumns: string[] = ['serReqId', 'productId', 'problem', 'currentStatus', 'updateStatus'];

  constructor(private serviceRequestService: ServiceBookingService) { }

  ngOnInit(): void {
    this.getServiceRequests();  // Fetch service requests on init
  }

  // Fetch all service requests for admin
  getServiceRequests(): void {
    this.serviceRequestService.getAllServiceRequests().subscribe(
      (requests: any) => {
        this.serviceRequests = requests.serviceRequests;
        // Populate updatedStatus with the current status initially
        this.serviceRequests.forEach((request: any) => {
          request.updatedStatus = request.status;
        });
      },
      (error) => {
        console.error('Error fetching service requests', error);
      }
    );
  }

  // Triggered when a status is selected from dropdown
  onStatusChange(request: any, newStatus: string): void {
    request.updatedStatus = newStatus;
  }

  // Update the status of a service request
  updateStatus(request: any): void {
    const updatedRequest = {
      ...request,
      status: request.updatedStatus  // Only status is updated
    };

    this.serviceRequestService.updateServiceRequest(updatedRequest).subscribe(
      (response: any) => {
        console.log('Status updated successfully', response);
        // Optionally refresh the list or show a success message
        this.getServiceRequests();
      },
      (error:any) => {
        console.error('Error updating service request', error);
      }
    );
  }
}
