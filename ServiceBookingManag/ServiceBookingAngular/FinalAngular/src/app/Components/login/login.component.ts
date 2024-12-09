import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Services/user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  errorMessage: string = '';
 

  constructor(private fb: FormBuilder, private router: Router,private userService: UserService) {
    // Form group initialization
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit(): void {
    // Initialization should only happen once, so this can be removed or kept here
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    }); // Corrected missing closing parenthesis
  }

  onSubmit(): void {
    
    if (this.loginForm.valid) {
      const { email, password } = this.loginForm.value;
  
    
      this.userService.login(email, password).subscribe(
        (response:any) => {
          console.log('Login successful:', response);
          if(response.status=="success")
          {
            // const { userId, userRole, token } = response;
            const token= response.jwttoken;
            const userId = response.userid;
            const userRole = response.role;

        // Store userId, userRole, and token
            this.userService.saveUserData(userId, userRole, token);
            if(response.role=="User")
            {
              this.router.navigate(['/user/user-dashboard']); // Navigate to user dashboard
            }
            else if (response.role === 'Admin') {
              this.router.navigate(['/admin/admin-dashboard']); // Navigate to user dashboard
            }
          // You can redirect the user to another page here
        }
        else{
          this.errorMessage = 'Invalid email or password.';
        }
      },
          (error: any)=> {
          console.error('Login failed:', error);
        }
      );

    } else {
      this.errorMessage = 'Invalid form submission.';
    }
  }
  
  
  
}
