import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../Services/auth.service';

import { Router } from '@angular/router';
import { map } from 'rxjs';

export const userGuardGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const currentUser = authService.getLoggedInUser();

  if (route.routeConfig?.path === 'register' && currentUser === null) {
    return true;
  }

  // If user is logged in and trying to access 'register', redirect to home
  if (route.routeConfig?.path === 'register' && currentUser !== null) {
    router.navigate(['/home']);
    return false;
  }
  
  if (currentUser && currentUser.userType === 'user') {
    return true;
  } else {
    router.navigate(['/signin']);
    return false;
  }
  // return authService.checkSession().pipe(
  //   map(isLoggedIn => {
  //     if (isLoggedIn) {
  //       return true;
  //     } else {
  //       router.navigate(['/signin']);
  //       return false;
  //     }
  //   })
  // );

};