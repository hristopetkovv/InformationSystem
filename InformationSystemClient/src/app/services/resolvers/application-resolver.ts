import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ApplicationService } from '../applications/application.service';

@Injectable({
  providedIn: 'root'
})

export class ApplicationResolver implements Resolve<any> {
  constructor(
    private resource: ApplicationService
  ) { }

  resolve(
    route: ActivatedRouteSnapshot,
    _: RouterStateSnapshot
  ): Observable<any> | Promise<any> | any {
    const id = +route.params['id'];
    if (isNaN(id) || id == null) {
      return this.resource.getAll();
    }

    return this.resource.getById(id);
  }
}