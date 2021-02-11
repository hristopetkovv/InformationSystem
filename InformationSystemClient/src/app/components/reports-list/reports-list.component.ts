import { Component, OnInit } from '@angular/core';
import { StatusType } from 'src/app/enums/statusType';
import { ReportDto } from 'src/app/models/report.dto';
import { ReportService } from 'src/app/services/report/report.service';

@Component({
  selector: 'app-reports-list',
  templateUrl: './reports-list.component.html',
  styleUrls: ['./reports-list.component.css']
})
export class ReportsListComponent implements OnInit {
  reports: ReportDto[] = [];
  status = StatusType;

  constructor(private reportService: ReportService) { }

  ngOnInit(): void {
    this.getReports();
  }

  getReports() {
    this.reportService.getReports().subscribe(reports => this.reports = reports);
  }
}
