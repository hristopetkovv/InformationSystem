import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReportDto } from 'src/app/models/report.dto';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private http: HttpClient) { }

  getReports(): Observable<ReportDto[]> {
    return this.http.get<ReportDto[]>('api/report');
  }
}
