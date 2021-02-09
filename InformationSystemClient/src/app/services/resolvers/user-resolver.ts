import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { EMPTY, Observable } from 'rxjs';
import { UsersService } from '../users/users.service';

@Injectable({
  providedIn: 'root'
})

export class UserResolver implements Resolve<any> {
  userId: number = +localStorage.getItem('userId');

  constructor(
    private resource: UsersService
  ) { }

  resolve(
    route: ActivatedRouteSnapshot,
    _: RouterStateSnapshot
  ): Observable<any> | Promise<any> | any {

    if (isNaN(this.userId)) {
      return EMPTY;
    }

    return this.resource.getById(this.userId);
  }
}