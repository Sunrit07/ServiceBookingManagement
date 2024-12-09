import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component'; // Adjust import as necessary
import { ProductManagementComponent } from './components/product-management/product-management.component';
import { ServiceBookingsComponent } from './components/service-bookings/service-bookings.component';
import { UserManagementComponent } from '../admin/components/user-management/user-management.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';

const routes: Routes = [
  {
    path: 'user-dashboard',
    component: UserDashboardComponent // Ensure the component exists
  },
   {
     path: 'product-management',
     component: ProductManagementComponent // Add as necessary
   },
   {
     path: 'service-bookings',
     component: ServiceBookingsComponent // Add as necessary
   },
  {
     path: 'user-profile',
     component: UserProfileComponent // Add as necessary
   }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
