import { Component, OnInit } from '@angular/core';
import { StatusType } from 'src/app/enums/statusType';
import { ReportDto } from 'src/app/models/report.dto';
import { SearchApplicationDto } from 'src/app/models/search-application.dto';
import { ReportService } from 'src/app/services/report/report.service';

@Component({
  selector: 'app-reports-list',
  templateUrl: './reports-list.component.html',
  styleUrls: ['./reports-list.component.css'],
  providers: [SearchApplicationDto]
})
export class ReportsListComponent implements OnInit {
  reports: ReportDto[] = [];
  status = StatusType;

  constructor(
    private reportService: ReportService,
    public applicationFilter: SearchApplicationDto) { }

  ngOnInit(): void {
    this.getReports(this.applicationFilter);
  }

  getReports($event: SearchApplicationDto) {
    this.reportService.getReports($event).subscribe(reports => this.reports = reports);
  }
}
