import { Component, OnInit } from '@angular/core';
import { StatusType } from 'src/app/enums/statusType';
import { ApplicationDto } from 'src/app/models/application.dto';
import { BaseApplicationDto } from 'src/app/models/baseApplication.dto';
import { SearchApplicationDto } from 'src/app/models/search-application.dto';
import { ApplicationResourceService } from 'src/app/services/application-resource.service';
import { ApplicationService } from 'src/app/services/applications/application.service';

@Component({
  selector: 'app-application-listing',
  templateUrl: './application-listing.component.html',
  styleUrls: ['./application-listing.component.css']
})
export class ApplicationListingComponent implements OnInit {

  apllicationsList: BaseApplicationDto[];
  applicationEnum = StatusType;
  role = JSON.parse(localStorage.getItem('user')).role;
  statusTypesEnum = StatusType;

  constructor(
    private applicationResourceService: ApplicationResourceService,
    private applicationService: ApplicationService,
    public applicationFilter: SearchApplicationDto
  ) { }

  ngOnInit(): void {
    this.applicationResourceService.getApplications(this.applicationFilter)
      .subscribe(applications => this.apllicationsList = applications);
  }

  getApplications($event: SearchApplicationDto) {
    this.applicationResourceService.getApplications($event)
      .subscribe(applications => this.apllicationsList = applications);
  }

  updateStatus(app: ApplicationDto, status: string) {

    if (status == 'approve') {
      this.applicationService
        .updateStatus(app.id, this.statusTypesEnum.Approved)
        .subscribe(data => app.status = this.statusTypesEnum.Approved);
    }
    else if (status == 'disapprove') {
      this.applicationService
        .updateStatus(app.id, this.statusTypesEnum.Disapproved)
        .subscribe(data => app.status = this.statusTypesEnum.Disapproved);
    }

  }

}
