import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApplicationDto } from 'src/app/models/application/application.dto';
import { SearchApplicationDto } from 'src/app/models/search/search-application.dto copy';
import { StatusType } from 'src/app/enums/statusType';

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

  updateStatus(id: number, status: StatusType): Observable<any> {
    return this.http.put(`api/Status/application/${id}`, status);
  }

  createApplication(application: ApplicationDto) {
    return this.http.post('api/application', application);
  }

  getApplications(applicationFilter: SearchApplicationDto): Observable<any[]> {
    return this.http.get<any[]>(`api/application${applicationFilter.getQueryString()}`);
  }

  removeApplication(applicationId: number) {
    return this.http.delete(`api/application/${applicationId}`);
  }

  exportAsExcel(applicationFilter: SearchApplicationDto): Observable<Blob> {
    return this.http.get(`api/application/excel${applicationFilter.getQueryString()}`, { responseType: 'blob' });
  }
}