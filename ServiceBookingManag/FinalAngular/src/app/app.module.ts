import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { HomeComponent } from './Components/home/home.component';
import { AboutUsComponent } from './Components/about-us/about-us.component';
import { HeaderComponent } from './shared/header/header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar'; // Import MatToolbarModule
import { MatRadioModule } from '@angular/material/radio';
import { UserHeaderComponent } from './modules/user/components/userheader/userheader.component';
import { CommonModule } from '@angular/common';
import { UserModule } from './modules/user/user.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserService } from './Services/user.service';
import { AuthInterceptor } from './Interceptors/auth-interceptor.interceptor';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table'; 

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    AboutUsComponent,
    HeaderComponent,
    
    
    
  ],
  

  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    MatCardModule,
    MatInputModule,
    MatToolbarModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatRadioModule,
    CommonModule, // Add this if it's missing
    UserModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTableModule
  ],
  providers: [UserService, // Updated provider for UserService
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor, // or UserInterceptor if you rename
      multi: true
    }],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
