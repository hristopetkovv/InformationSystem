import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { EMPTY, Observable } from 'rxjs';
import { MessageService } from '../message/message.service';

@Injectable({
  providedIn: 'root'
})

export class MessageResolver implements Resolve<any> {
  constructor(
    private resource: MessageService
  ) { }

  resolve(
    route: ActivatedRouteSnapshot,
    _: RouterStateSnapshot
  ): Observable<any> | Promise<any> | any {
    const id = +route.params['id'];

    if (isNaN(id)) {
      return EMPTY;
    }

    return this.resource.getMessageById(id);
  }
}