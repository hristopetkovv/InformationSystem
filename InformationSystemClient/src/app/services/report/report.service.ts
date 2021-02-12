import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ReportDto } from 'src/app/models/report.dto';
import { SearchApplicationDto } from 'src/app/models/search-application.dto';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private http: HttpClient) { }

  getReports(applicationFilter: SearchApplicationDto): Observable<ReportDto[]> {
    return this.http.get<ReportDto[]>(`api/report${applicationFilter.getQueryString()}`);
  }
}
