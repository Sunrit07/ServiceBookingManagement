import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { ServiceReportsComponent } from './components/service-reports/service-reports.component';
import { UserManagementComponent } from './components/user-management/user-management.component';
import { AdminHeaderComponent } from './components/adminheader/adminheader.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table'; 

@NgModule({
  declarations: [
    AdminDashboardComponent,
    ServiceReportsComponent,
    UserManagementComponent,
    AdminHeaderComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTableModule

  ]
})
export class AdminModule { }
