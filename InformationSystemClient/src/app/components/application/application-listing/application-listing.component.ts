import { Component, OnInit } from '@angular/core';
import { StatusType } from 'src/app/enums/statusType';
import { BaseApplicationDto } from 'src/app/models/baseApplication.dto';
import { ApplicationResourceService } from 'src/app/services/application-resource.service';

@Component({
  selector: 'app-application-listing',
  templateUrl: './application-listing.component.html',
  styleUrls: ['./application-listing.component.css']
})
export class ApplicationListingComponent implements OnInit {

  apllicationsList: BaseApplicationDto[];
  applicationEnum = StatusType;

  constructor(private applicationService: ApplicationResourceService) { }

  ngOnInit(): void {
    this.getApplications();
  }

  getApplications() {
    this.applicationService.getApplications().subscribe(applications => this.apllicationsList = applications);
  }
}
