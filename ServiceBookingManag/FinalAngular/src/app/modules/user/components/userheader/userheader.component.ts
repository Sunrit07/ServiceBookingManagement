import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-user-header',
  templateUrl: './userheader.component.html',
  styleUrls: ['./userheader.component.css']
})
export class UserHeaderComponent {
  isDarkMode: boolean = false;

  constructor(private router: Router) {}

  toggleDarkMode() {
    this.isDarkMode = !this.isDarkMode;
  }

  signOut() {
    // Handle sign-out logic here, e.g., clear tokens, redirect to sign-in page
    localStorage.removeItem('userId',);
    localStorage.removeItem('userRole');
    localStorage.removeItem('jwtToken');
    this.router.navigate(['/signin']);
  }
}
