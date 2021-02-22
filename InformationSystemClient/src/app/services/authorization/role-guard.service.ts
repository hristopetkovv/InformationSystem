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
        let isAdmin = this.userSerive.isAdmin();
        let actualRole: string;

        if (isAdmin == true) {
            actualRole = 'Admin';
        }

        return actualRole == expectedRole;
    }
}
