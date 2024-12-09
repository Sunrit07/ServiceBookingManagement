import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceBookingService } from 'src/app/Services/service-booking.service';
import { UserService } from 'src/app/Services/user.service';


@Component({
  selector: 'app-service-bookings',
  templateUrl: './service-bookings.component.html',
  styleUrls: ['./service-bookings.component.css']
})
export class ServiceBookingsComponent implements OnInit {
  serviceRequests: any[] = [];
  requestForm: FormGroup;
  errorMessage: string = '';
  successMessage: string = '';
  isUpdate: boolean = false; // Flag to determine whether we are updating or creating  selectedRequestId: number | null = null; // Store the request being edited
  userId: any;
  len:any;
  selectedRequestId: number | null = null; // Store the ID of the request being updated


  constructor(private userService: UserService, private fb: FormBuilder,private serviceRequestsService:ServiceBookingService) {
    // Initialize the form for creating a service request
    this.requestForm = this.fb.group({
      productId:['', [Validators.required, Validators.min(0)]],
      problem: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.userId = this.userService.getUserId();
    if (this.userId) {
      this.loadServiceRequests();
    } else {
      console.error('User is not logged in.');
    }
    
  }
  

  // Load service requests for the current user
  loadServiceRequests(): void {
    this.serviceRequestsService.getServiceRequestsByUserId(this.userId).subscribe({
      next: (response) => {
        if (response.status === 'success') {
          this.serviceRequests = response.serviceRequests;
        } else {
          this.errorMessage = 'No service requests found.';
        }
      },
      error: () => {
        this.errorMessage = 'Failed to load service requests.';
      }
    });
  }

  
  // Create or update a service request
  onSubmit(): void {
    if (this.requestForm.valid) {
      const requestData = {
        userId: this.userId,
        reqDate: new Date().toISOString(),
        ...this.requestForm.value,
        status: 'Pending'
      };

      if (this.isUpdate && this.selectedRequestId) {
        // Update existing service request
        this.updateServiceRequest(this.selectedRequestId, requestData);
      } else {
        // Create a new service request
        this.createServiceRequest(requestData);
      }
    }
  }

  // Create a new service request
  createServiceRequest(requestData: any): void {
    this.serviceRequestsService.createServiceRequest(requestData).subscribe({
      next: (response) => {
        if (response.status === 'success') {
          this.successMessage = 'Service request created successfully!';
          this.loadServiceRequests(); // Refresh the list
          this.requestForm.reset(); // Reset the form
        } else {
          this.errorMessage = 'Failed to create service request.';
        }
      },
      error: () => {
        this.errorMessage = 'Failed to create service request.';
      }
    });
  }

  // Update an existing service request
  updateServiceRequest(requestId: number, requestData: any): void {
    requestData.serReqId = requestId; // Add the request ID to the requestData
    this.serviceRequestsService.updateServiceRequest(requestData).subscribe({
      next: (response:any) => {
        if (response.status === 'success') {
          this.successMessage = 'Service request updated successfully!';
          this.loadServiceRequests();
          this.requestForm.reset();
          this.isUpdate = false; // Reset update mode
          this.selectedRequestId = null;
        } else {
          this.errorMessage = 'Failed to update service request.';
        }
      },
      error: () => {
        this.errorMessage = 'Failed to update service request.';
      }
    });
  }

  // Delete a service request
  deleteServiceRequest(requestId: number): void {
    this.serviceRequestsService.deleteServiceRequest(requestId).subscribe({
      next: (response:any) => {
        if (response.status === 'success') {
          this.successMessage = 'Service request deleted successfully!';
          this.loadServiceRequests();
        } else {
          this.errorMessage = 'Failed to delete service request.';
        }
      },
      error: () => {
        this.errorMessage = 'Failed to delete service request.';
      }
    });
  }

  // Populate form with existing data for update
  editRequest(request: any): void {
    this.requestForm.patchValue({
      productId: request.productId,
      problem: request.problem,
      description: request.description,
    });
    this.isUpdate = true;
    this.selectedRequestId = request.serReqId; // Store the selected request ID for update
  }

  // Reset form and state
  resetForm(): void {
    this.requestForm.reset();
    this.isUpdate = false;
    this.selectedRequestId = null;
    this.successMessage = '';
    this.errorMessage = '';
  }
  }


  




