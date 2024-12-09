import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:7174/api/AppProduct';
  constructor(private http:HttpClient,private userService:UserService) { }
  getAllProducts(userId: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/GetAllProducts/${userId}`);
  }
  addProduct(productData: any): Observable<any> {
    const userId = this.userService.getUserId(); // Fetch userId from localStorage

    if (!userId) {
      throw new Error('User not logged in');
    }

    const requestBody = {
      ...productData,
      userId: userId, // Automatically associate product with logged-in user
      //createdDate: new Date().toISOString() // Auto-generate the current date
    };

    return this.http.post(`${this.apiUrl}/AddProduct`, requestBody);
  }

  // Method to update an existing product
  updateProduct(productData: any): Observable<any> {
    const requestBody = {
      ...productData,
      createdDate: new Date().toISOString() // Ensure createdDate is updated
    };
    return this.http.put(`${this.apiUrl}/UpdateProduct`, requestBody);
  }
  deleteProduct(productId: number): Observable<any> {
    const url = `${this.apiUrl}/${productId}`;
    return this.http.delete(url);
  }

}
