import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Import here

import { UserRoutingModule } from './user-routing.module';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { ProductManagementComponent } from './components/product-management/product-management.component';
import { ServiceBookingsComponent } from './components/service-bookings/service-bookings.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { RouterModule } from '@angular/router';
import { UserHeaderComponent } from './components/userheader/userheader.component';

@NgModule({
  declarations: [
    UserDashboardComponent,
    ProductManagementComponent,
    ServiceBookingsComponent,
    UserProfileComponent,
    UserHeaderComponent,
    
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    RouterModule,
    ReactiveFormsModule, // Add this line
    FormsModule
  ]
})
export class UserModule { }
