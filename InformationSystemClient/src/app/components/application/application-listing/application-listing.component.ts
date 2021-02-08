import { Component, OnInit } from '@angular/core';
import { ApplicationResourceService } from 'src/app/services/application-resource.service';

@Component({
  selector: 'app-application-listing',
  templateUrl: './application-listing.component.html',
  styleUrls: ['./application-listing.component.css']
})
export class ApplicationListingComponent implements OnInit {

  constructor(private applicationService: ApplicationResourceService) { }

  ngOnInit(): void {
    this.getApplications();
  }

  getApplications() {
    this.applicationService.getApplications().subscribe(applications => console.log(applications));
  }
}
