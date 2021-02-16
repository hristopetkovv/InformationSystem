import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApplicationDto } from 'src/app/models/application.dto';
import { SearchApplicationDto } from 'src/app/models/search-application.dto';

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

  getApplications(applicationFilter: SearchApplicationDto): Observable<any[]> {
    return this.http.get<any[]>(`api/application${applicationFilter.getQueryString()}`);
  }

  isAuthor(creatorId: number): boolean {
    let userId = JSON.parse(localStorage.getItem('user')).id;
    return creatorId == userId;
  }

  exportAsExcel(applicationFilter: SearchApplicationDto): Observable<Blob> {
    return this.http.get(`api/application/excel${applicationFilter.getQueryString()}`, { responseType: 'blob' });
  }
}