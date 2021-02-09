import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApplicationDto } from 'src/app/models/application.dto';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
  constructor(
    private http: HttpClient
  ) {
  }

  getById(id: number): Observable<any> {
    return this.http.get(`api/Application/${id}`);
  }

  update(id: number, application: ApplicationDto) {
    return this.http.put(`api/Application/${id}`, application);
  }
}