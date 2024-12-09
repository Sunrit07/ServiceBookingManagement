import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  isDarkMode: boolean = false; // Initialize to false or true based on your preference

  toggleDarkMode(): void {
    this.isDarkMode = !this.isDarkMode;
    // You might also want to store the preference in local storage
    localStorage.setItem('darkMode', JSON.stringify(this.isDarkMode));
  }

  ngOnInit(): void {
    // Retrieve dark mode preference from local storage if needed
    const storedMode = localStorage.getItem('darkMode');
    if (storedMode) {
      this.isDarkMode = JSON.parse(storedMode);
    }
  }
}
