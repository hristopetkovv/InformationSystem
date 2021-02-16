import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, UrlTree, RouterStateSnapshot } from '@angular/router';
import { UsersService } from '../users/users.service';

@Injectable({
    providedIn: 'root'
})

export class RoleGuardService implements CanActivate {

    constructor(
        public router: Router,
        public userSerive: UsersService
    ) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        _: RouterStateSnapshot): boolean | UrlTree {

        const expectedRole = route.data.expectedRole;
        const actualRole = this.userSerive.getRole();

        return actualRole == expectedRole;
    }
}
