import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SearchApplicationDto } from '../../models/search-application.dto';

@Injectable({
  providedIn: 'root'
})
export class ApplicationResourceService {

  constructor(private http: HttpClient) { }

  getApplications(applicationFilter: SearchApplicationDto): Observable<any[]> {
    return this.http.get<any[]>(`api/application${applicationFilter.getQueryString()}`);
  }
}
