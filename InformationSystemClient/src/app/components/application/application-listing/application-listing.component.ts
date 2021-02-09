import { Component, OnInit } from '@angular/core';
import { StatusType } from 'src/app/enums/statusType';
import { BaseApplicationDto } from 'src/app/models/baseApplication.dto';
import { SearchApplicationDto } from 'src/app/models/search-application.dto';
import { ApplicationResourceService } from 'src/app/services/application-resource.service';

@Component({
  selector: 'app-application-listing',
  templateUrl: './application-listing.component.html',
  styleUrls: ['./application-listing.component.css']
})
export class ApplicationListingComponent implements OnInit {

  apllicationsList: BaseApplicationDto[];
  applicationEnum = StatusType;

  constructor(private applicationService: ApplicationResourceService, public applicationFilter: SearchApplicationDto) { }

  ngOnInit(): void {
    this.getApplications();
  }

  getApplications() {
    this.applicationService.getApplications(this.applicationFilter)
      .subscribe(applications => this.apllicationsList = applications);
  }
}
