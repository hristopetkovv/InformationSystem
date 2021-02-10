import { JsonPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { faPennyArcade } from '@fortawesome/free-brands-svg-icons';
import { ApplicationType } from 'src/app/enums/applicationType';
import { QualificationType } from 'src/app/enums/qualificationType';
import { StatusType } from 'src/app/enums/statusType';
import { ApplicationDto } from 'src/app/models/application.dto';
import { QualificationInfo } from 'src/app/models/qualificationInformation.dto';
import { ApplicationService } from 'src/app/services/applications/application.service';

@Component({
  selector: 'app-application-details',
  templateUrl: './application-details.component.html',
  styleUrls: ['./application-details.component.css']
})
export class ApplicationDetailsComponent implements OnInit {
  application = new ApplicationDto();
  role = JSON.parse(localStorage.getItem('user')).role;
  canEdit: boolean;

  applicationTypesEnum = ApplicationType;
  statusTypesEnum = StatusType;
  qualificationTypesEnum = QualificationType;

  constructor(
    private route: ActivatedRoute,
    private applicationService: ApplicationService
  ) { }

  ngOnInit(): void {
    this.route.data
      .subscribe((data: any) => this.application = data.application);
  }

  saveApplication() {
    this.applicationService.update(this.application.id, this.application).subscribe();
  }

  sendQualification() {
    this.applicationService.updateStatus(this.application.id, this.statusTypesEnum.InProcess)
      .subscribe(data => this.application.status = this.statusTypesEnum.InProcess);
  }

}