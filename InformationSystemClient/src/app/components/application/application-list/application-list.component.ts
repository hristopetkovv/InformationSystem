import { Component, OnInit } from '@angular/core';
import { ApplicationService } from 'src/app/services/applications/application.service';
import * as FileSaver from 'file-saver';
import { ApplicationDto } from 'src/app/models/application/application.dto';
import { StatusType } from 'src/app/enums/statusType';
import { BaseApplicationDto } from 'src/app/models/application/baseApplication.dto';
import { SearchApplicationDto } from 'src/app/models/search/search-application.dto copy';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-application-list',
  templateUrl: './application-list.component.html',
  styleUrls: ['./application-list.component.css'],
  providers: [SearchApplicationDto]
})
export class ApplicationListComponent implements OnInit {

  applicationsList: BaseApplicationDto[];

  applicationEnum = StatusType;
  statusTypesEnum = StatusType;

  page = 1;
  pageSize = 4;
  collectionSize: number;

  constructor(
    private applicationService: ApplicationService,
    public applicationFilter: SearchApplicationDto,
    public userService: UsersService
  ) { }

  ngOnInit(): void {
    this.getApplications(this.applicationFilter);
  }

  getApplications(filter: SearchApplicationDto) {
    this.applicationService.getApplications(filter)
      .subscribe(applications => {
        this.applicationsList = applications.slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
        this.collectionSize = applications.length
      });
  }

  updateStatus(application: ApplicationDto, status: StatusType) {
    this.applicationService
      .updateStatus(application.id, status)
      .subscribe(() => application.status = status);
  }

  removeApplication(applicationId: number) {
    this.applicationService
      .removeApplication(applicationId)
      .subscribe(() => this.getApplications(this.applicationFilter));
  }

  exportExcel() {
    this.applicationService.exportAsExcel(this.applicationFilter)
      .subscribe(data => {
        const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8' });
        FileSaver.saveAs(blob, 'ExcelSheet.xlsx');
      });
  }
}
