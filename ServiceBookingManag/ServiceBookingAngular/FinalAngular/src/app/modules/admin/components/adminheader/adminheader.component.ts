import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-header',
  templateUrl: './adminheader.component.html',
  styleUrls: ['./adminheader.component.css']
})
export class AdminHeaderComponent {
  isDarkMode: boolean = false;

  constructor(private router: Router) {}

  toggleDarkMode() {
    this.isDarkMode = !this.isDarkMode;
  }

  signOut() {
    // Handle sign-out logic here, e.g., clear tokens, redirect to sign-in page
    localStorage.removeItem('authToken');
    this.router.navigate(['/signin']);
  }
}
