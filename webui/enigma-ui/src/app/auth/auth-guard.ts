import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private _authService: AuthService, private _router: Router) {}

  async canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Promise<boolean> {
    if (this._authService.isUserLoggedInSync()) {
      return true;
    } else {
      this._router.navigate(['/login'], {
        queryParams: { origin: route.url, originParams: JSON.stringify(route.queryParams)},
        queryParamsHandling: 'merge',
      });

      return false;
    }
  }
}