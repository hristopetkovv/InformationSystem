import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { UsersService } from '../users/users.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuardService implements CanActivate {

  constructor(
    private authService: UsersService
  ) { }

  canActivate(
    _: ActivatedRouteSnapshot,
    __: RouterStateSnapshot): boolean | UrlTree {

    return this.authService.isLogged();
  }

}
