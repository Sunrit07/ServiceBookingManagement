import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../../../Services/user.service'
import { Router } from '@angular/router';
import * as bcrypt from 'bcryptjs';
@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  userProfile: any;
  userProfileForm: FormGroup;
  isEditing = false;
  successMessage = '';
  errorMessage = '';
  userId: any;
  private readonly saltRounds = 10;

  constructor(
    private userService: UserService,
    private fb: FormBuilder,
    private router: Router
  ) {
    // Initialize the form
    this.userProfileForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      mobile: ['', Validators.required],
      password: ['', Validators.required],
      userRole: [{ value: '', disabled: true }],
      registrationDate: [{ value: '', disabled: true }]
    });
  }

  ngOnInit(): void {
    this.userId = this.userService.getUserId(); 
    this.loadUserProfile();
  }

  // Load current user's profile details
  loadUserProfile(): void {
    this.userService.getUserProfile(this.userId).subscribe({
      next: (response) => {
        if (response.status === 'success') {
          this.userProfile = response.payload;
          this.userProfileForm.patchValue({
            name: this.userProfile.name,
            email: this.userProfile.email,
            mobile: this.userProfile.mobile,
            password: '',  // Hide password by default
            userRole: this.userProfile.userRole,
            registrationDate: this.userProfile.registrationDate
          });
        }
      },
      error: (error) => {
        this.errorMessage = 'Failed to load profile data';
      }
    });
  }

  // Enable editing mode
  onEdit(): void {
    this.isEditing = true;
  }

  // Save changes (update profile)
  async onSaveChanges(): Promise<void>{
    if (this.userProfileForm.valid) {
      const hashedPassword = await bcrypt.hash(this.userProfileForm.value.password, this.saltRounds);
      const updatedData = {
        userId: this.userProfile.userId,
        name: this.userProfileForm.value.name,
        email: this.userProfileForm.value.email,
        mobile: this.userProfileForm.value.mobile,
        password: hashedPassword,//this.userProfileForm.value.password,  // Include password changes if needed
        userRole: this.userProfile.userRole,  // User role remains unchanged
        registrationDate: this.userProfile.registrationDate  // Keep registration date unchanged
      };

      this.userService.updateUserProfile(updatedData).subscribe({
        next: (response) => {
          if (response.status === 'success') {
            this.successMessage = 'Profile updated successfully';
            this.isEditing = false;
            this.loadUserProfile(); // Reload the updated profile


          }
        },
        error: (error) => {
          this.errorMessage = 'Failed to update profile';
        }
      });
    }
  }
  
}
