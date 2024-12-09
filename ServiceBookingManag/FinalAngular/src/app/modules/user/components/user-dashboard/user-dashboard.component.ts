import { Component, OnInit } from '@angular/core';
//import { BookingService } from 'src/app/Services/booking.service'; // Adjust path as necessary
import { ServiceBookingService } from 'src/app/Services/service-booking.service';
import { UserService } from 'src/app/Services/user.service';


@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {
  serviceRequests: any[] = [];
  currentYear: number;
  userId:any;
  errorMessage: string=''; 


  constructor(private serviceRequestsService:ServiceBookingService,private userService: UserService) {
    this.currentYear = new Date().getFullYear(); // Set the current year
  }


  ngOnInit() {
    this.userId = this.userService.getUserId();
    if (this.userId) {
      this.loadServiceRequests();
    } else {
      console.error('User is not logged in.');
    }
    
  }
  loadServiceRequests(): void {
    this.serviceRequestsService.getServiceRequestsByUserId(this.userId).subscribe({
      next: (response) => {
        if (response.status === 'success') {
          this.serviceRequests = response.serviceRequests; // Adjust based on your API response structure
        } else {
          this.errorMessage = 'No service requests found.';
        }
      },
      error: () => {
        this.errorMessage = 'Failed to load service requests.';
      }
    });
  }
}
