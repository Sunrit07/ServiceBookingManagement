import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl ='https://localhost:7174/api/AppUser';
  constructor(private http: HttpClient) { }
  login(email: string, password: string): Observable<any> {
    const body = { email, password };
    return this.http.post(`${this.apiUrl}/login`, body);
  }
  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }
  getUserProfile(userId: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/UserOnly/${userId}`);
  }
  updateUserProfile(userData: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/UpdateUser`, userData);
  }

  saveUserData(userId: number, userRole: string, token: string): void {
    localStorage.setItem('userId', userId.toString());
    localStorage.setItem('userRole', userRole);
    localStorage.setItem('jwtToken', token);
  }
  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }
  getUserId(): number | null {
    const userId = localStorage.getItem('userId');
    return userId ? +userId : null;
  }


  // Get userRole
  getUserRole(): string | null {
    return localStorage.getItem('userRole');
  }

  // Clear all stored data
  clearUserData(): void {
    localStorage.removeItem('userId');
    localStorage.removeItem('userRole');
    localStorage.removeItem('jwtToken');
  }

}
