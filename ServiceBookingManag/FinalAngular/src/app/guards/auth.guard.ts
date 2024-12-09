import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../Services/auth.service';
import { Router } from '@angular/router';

const restrictedRoutes: string[] = [
  '',          
  'home',
  'signin',
  'register',
  'contactUs',
  'aboutUs'
];

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const currentUser = authService.getLoggedInUser();
  const currentPath = state.url.slice(1);

  const isRestrictedRoute = restrictedRoutes.some(path => currentPath.startsWith(path));

  if (isRestrictedRoute) {
    if (currentUser?.userType=='user') {

      router.navigate(['/user-dashboard']);
      return false;
    } else {
      
      return true;
    }
    
  }

  return true;
};
