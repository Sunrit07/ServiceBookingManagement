import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceBookingService {

  private apiUrl = 'https://localhost:7174/api/AppService';

  constructor(private http: HttpClient) { }

  // Existing method to create a service request
  createServiceRequest(requestData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/CreateRequestUserOnly`, requestData);
  }
  // Update a service request
  updateServiceRequest(requestData: any) {
    return this.http.put(`${this.apiUrl}/updateRequestUserOnly`, requestData);
  }

  // Delete a service request
  deleteServiceRequest(requestId: number) {
    return this.http.delete(`${this.apiUrl}/DeleteRequestUser/${requestId}`);
  }


  // New method to get service requests by user ID
  getServiceRequestsByUserId(userId: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/getservicerequestsUserOnly/${userId}`);
  }

  getAllServiceRequests(): Observable<any>{
    return this.http.get(`${this.apiUrl}/getservicerequestsAdminOnly`);
  }


}
