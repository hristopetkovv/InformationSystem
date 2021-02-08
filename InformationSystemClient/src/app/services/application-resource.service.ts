import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApplicationResourceService {

  constructor(private http: HttpClient) { }

  getApplications(): Observable<any[]> {
    return this.http.get<any[]>('api/application');
  }
}
