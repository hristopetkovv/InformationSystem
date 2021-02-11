import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApplicationType } from 'src/app/enums/applicationType';
import { QualificationType } from 'src/app/enums/qualificationType';
import { ApplicationDto } from 'src/app/models/application.dto';
import { QualificationInformation } from 'src/app/models/qualificationInformation.dto';
import { ApplicationService } from 'src/app/services/applications/application.service';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-application-creating',
  templateUrl: './application-creating.component.html',
  styleUrls: ['./application-creating.component.css']
})
export class ApplicationCreatingComponent implements OnInit {
  application: ApplicationDto = new ApplicationDto();
  qualificationArray: QualificationInformation[] = [];
  qualification: QualificationInformation = new QualificationInformation();

  applicationTypesEnum = ApplicationType;
  qualificationTypesEnum = QualificationType;

  constructor(
    private userService: UsersService,
    private router: Router,
    private applicationService: ApplicationService,
  ) { }

  ngOnInit(): void {
  }

  createApplication() {
    this.application.userFirstName = this.userService.getUserNames().FirstName;
    this.application.userLastName = this.userService.getUserNames().LastName;
    this.applicationService.createApplication(this.application).subscribe(() => this.router.navigateByUrl('/applications'));
  }

  addRow() {
    this.qualificationArray.push(this.qualification);
    this.application.qualificationInformation.push(this.qualification);
    this.qualification = new QualificationInformation();
  }

  deleteRow(index) {
    this.application.qualificationInformation.splice(index, 1)
    this.qualificationArray.splice(index, 1);
  }

  cancel() {
    this.router.navigateByUrl('applications');
  }
}
