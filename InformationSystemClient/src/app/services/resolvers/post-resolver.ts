import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { EMPTY, Observable } from 'rxjs';
import { PostService } from '../post/post.service';

@Injectable({
  providedIn: 'root'
})

export class PostResolver implements Resolve<any> {
  constructor(
    private resource: PostService
  ) { }

  resolve(
    route: ActivatedRouteSnapshot,
    _: RouterStateSnapshot
  ): Observable<any> | Promise<any> | any {
    const id = +route.params['id'];
    console.log(id);

    if (isNaN(id)) {
      return EMPTY;
    }

    return this.resource.getById(id);
  }
}