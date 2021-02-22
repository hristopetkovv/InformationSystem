import { Component, OnInit } from '@angular/core';
import { ApplicationService } from 'src/app/services/applications/application.service';
import * as FileSaver from 'file-saver';
import { ApplicationDto } from 'src/app/models/application/application.dto';
import { StatusType } from 'src/app/enums/statusType';
import { BaseApplicationDto } from 'src/app/models/application/baseApplication.dto';
import { SearchApplicationDto } from 'src/app/models/search/search-application.dto copy';
import { UsersService } from 'src/app/services/users/users.service';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';

@Component({
  selector: 'app-application-list',
  templateUrl: './application-list.component.html',
  styleUrls: ['./application-list.component.css'],
  providers: [SearchApplicationDto]
})
export class ApplicationListComponent implements OnInit {

  apllicationsList: BaseApplicationDto[];
  applicationEnum = StatusType;
  isAdmin: boolean;
  statusTypesEnum = StatusType;

  constructor(
    private applicationService: ApplicationService,
    public applicationFilter: SearchApplicationDto,
    private userService: UsersService
  ) { }

  ngOnInit(): void {
    this.getApplications(this.applicationFilter);
    this.isAdmin = this.userService.isAdmin();
  }

  getApplications(filter: SearchApplicationDto) {
    this.applicationService.getApplications(filter)
      .subscribe(applications => this.apllicationsList = applications);
  }

  updateStatus(application: ApplicationDto, status: StatusType) {
    this.applicationService
      .updateStatus(application.id, status)
      .subscribe(() => application.status = this.statusTypesEnum.Approved);
  }

  exportExcel() {
    this.applicationService.exportAsExcel(this.applicationFilter)
      .subscribe(data => {
        const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8' });
        FileSaver.saveAs(blob, 'ExcelSheet.xlsx');
      });
  }

}
