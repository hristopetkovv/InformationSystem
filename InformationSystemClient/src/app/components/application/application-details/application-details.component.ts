import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApplicationType } from 'src/app/enums/applicationType';
import { QualificationType } from 'src/app/enums/qualificationType';
import { StatusType } from 'src/app/enums/statusType';
import { ApplicationDto } from 'src/app/models/application.dto';

@Component({
  selector: 'app-application-details',
  templateUrl: './application-details.component.html',
  styleUrls: ['./application-details.component.css']
})
export class ApplicationDetailsComponent implements OnInit {
  keys: any[];
  application = new ApplicationDto();
  applicationTypesEnum = ApplicationType;
  statusTypesEnum = StatusType;
  qualificationTypesEnum = QualificationType;

  constructor(private route: ActivatedRoute) {
    this.keys = Object.keys(this.applicationTypesEnum).filter(k => !isNaN(Number(k)));
  }

  ngOnInit(): void {
    this.route.data.subscribe((data: any) => this.application = data.application);
  }

}
