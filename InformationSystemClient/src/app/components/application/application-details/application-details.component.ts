import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StatusType } from 'src/app/enums/statusType';
import { ApplicationDto } from 'src/app/models/application.dto';
import { ApplicationService } from 'src/app/services/applications/application.service';

@Component({
  selector: 'app-application-details',
  templateUrl: './application-details.component.html',
  styleUrls: ['./application-details.component.css']
})
export class ApplicationDetailsComponent implements OnInit {
  application = new ApplicationDto();
  user = JSON.parse(localStorage.getItem('user'));
  role = this.user.role;
  canEdit: boolean;

  statusTypesEnum = StatusType;

  constructor(
    private route: ActivatedRoute,
    private applicationService: ApplicationService,
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