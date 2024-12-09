import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';
import { RegisterComponent } from './Components/register/register.component';
import { HomeComponent } from './Components/home/home.component';
import { AboutUsComponent } from './Components/about-us/about-us.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: '/home', pathMatch: 'full'
  },
    {path: 'home',
      component: HomeComponent,
      
  },

    {
      path: 'signin',
    component: LoginComponent
    },
    {
    path: 'register',
    component: RegisterComponent,
    
    
  },
  { path: 'login', component: LoginComponent },
  {
    path: 'about-us',
    component: AboutUsComponent,
  },

  {
    path: 'user',
    loadChildren: () => import('./modules/user/user.module').then(m => m.UserModule)
  },
  {
    path: 'admin',
    loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)
  }
  
  // { path: 'admin-dashboard',canActivate:[AdminGuard], loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule) },
  // { path: 'user-dashboard', canActivate: [UserGuard], loadChildren: () => import('./modules/user/user.module').then(m => m.UserModule) },

  
  
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
