import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { UsersService } from './users.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {
  constructor(private router: Router, private authService: UsersService) {
  }

  canActivate(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean | UrlTree {

    if (!this.authService.isLogged()) {

      this.router.navigate(["home"], { queryParams: { retUrl: route.url } });
      return false;
    }

    return true;
  }
}
