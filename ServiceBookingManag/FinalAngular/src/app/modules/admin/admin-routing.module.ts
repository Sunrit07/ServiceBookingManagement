import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { UserManagementComponent } from './components/user-management/user-management.component';
import { ServiceReportsComponent } from './components/service-reports/service-reports.component'; // Adjust paths as necessary

const routes: Routes = [
  {
    path: 'admin-dashboard',
    component: AdminDashboardComponent
  },
  {
    path: 'user-management',
    component: UserManagementComponent
  },
  {
    path: 'service-reports',
    component: ServiceReportsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
