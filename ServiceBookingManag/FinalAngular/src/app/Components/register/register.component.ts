import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private router: Router,private userService: UserService) {
    // Initialize the form group here
    this.registerForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
      mobile: ['',[Validators.required, Validators.minLength(10),Validators.maxLength(10)]],
      role: ['User'] // Default role
    });
  }

  ngOnInit(): void {
    // Additional initialization if needed
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      //const users = JSON.parse(localStorage.getItem('users') || '[]'); // Get existing users array or empty array
      //const existingUser = users.find((user: any) => user.email === this.registerForm.value.email); // Check if email already exists
  
      // if (existingUser) {
      //   this.errorMessage = 'User already registered. Please login.';
      // } else {
        const newUser = {
          name: this.registerForm.value.name,
          email: this.registerForm.value.email,
          password: this.registerForm.value.password,
          mobile: this.registerForm.value.mobile,
          userRole: this.registerForm.value.role
        };
  
      //   users.push(newUser); // Add new user to the array
      //   localStorage.setItem('users', JSON.stringify(users)); // Store the updated array in localStorage
      //   this.successMessage = 'Registration successful! You can now login.';
      this.userService.register(newUser).subscribe(
        response => {
          console.log('Registration successful:', response);
          // You can redirect the user to another page here
        },
        error => {
          console.error('Registration failed:', error);
        }
      );
      this.router.navigate(['/login']);
    }
        
  }
  
    
  
  
}
