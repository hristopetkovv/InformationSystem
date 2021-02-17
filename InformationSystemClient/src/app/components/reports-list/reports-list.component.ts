import { Component, OnInit } from '@angular/core';
import { StatusType } from 'src/app/enums/statusType';
import { ReportDto } from 'src/app/models/report/report.dto';
import { ReportService } from 'src/app/services/report/report.service';
import * as XLSX from 'xlsx';
import * as FileSaver from 'file-saver';
import { SearchApplicationDto } from 'src/app/models/search/search-application.dto copy';

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

  getReports(filter: SearchApplicationDto) {
    this.reportService.getReports(filter)
      .subscribe(reports => this.reports = reports);
  }

  exportExcel() {
    this.reportService.exportAsExcel(this.applicationFilter)
      .subscribe(data => {
        const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8' });
        FileSaver.saveAs(blob, 'ExcelSheet.xlsx');
      });

  }
}
