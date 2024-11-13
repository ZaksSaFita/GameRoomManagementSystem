import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {AuthService} from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    //control if user is auth...
    if (!this.authService.isAuthenticated()) {
      this.router.navigate(['/auth/login']);
      return false;
    }

    //control the role of the user
    const expectedRole = route.data['expectedRole'];
    const role = this.authService.getUserInfoFromToken()?.role;
    //if the role is correct give permission
    if (role && expectedRole && expectedRole.includes(role)) {
      return true;
    } else {
      this.router.navigate(['/']);
      return false;
    }

  }


}
