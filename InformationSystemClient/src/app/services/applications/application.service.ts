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

  update(id: number, application: ApplicationDto): Observable<any> {
    return this.http.put(`api/Application/${id}`, application);
  }

  updateStatus(id: number, status: number): Observable<any> {
    return this.http.put(`api/Status/${id}`, status);
  }

  createApplication(application: ApplicationDto) {
    return this.http.post('api/application', application);
  }
}