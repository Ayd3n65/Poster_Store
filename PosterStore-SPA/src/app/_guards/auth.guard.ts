import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AlertifyService } from '../_services/alertify.service';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AccountService, private router: Router,
  private alertify: AlertifyService) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      const roles = next.firstChild.data['roles'] as Array<string>;
      // if (roles) {
      //   const match = this.authService.roleMatch(roles);
      //   if (match) {
      //     return true;
      //   } else {
      //     this.router.navigate(['members']);
      //     this.alertify.error('You are not authorized to access this area');
      //   }
      // }

      if (this.authService.loggedIn()) {
        return true;
      }

      this.alertify.error('You shall not pass!!!');
      this.router.navigate(['/home']);
      return false;
  }
}
