import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StatusType } from 'src/app/enums/statusType';
import { ApplicationDto } from 'src/app/models/application/application.dto';
import { ApplicationService } from 'src/app/services/applications/application.service';

@Component({
  selector: 'app-application-details',
  templateUrl: './application-details.component.html',
  styleUrls: ['./application-details.component.css']
})
export class ApplicationDetailsComponent implements OnInit {
  application = new ApplicationDto();

  canEdit: boolean;
  isAuthor: boolean;

  statusTypesEnum = StatusType;

  constructor(
    private route: ActivatedRoute,
    private applicationService: ApplicationService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.data
      .subscribe((data: any) => this.application = data.application);
    this.isEditAllowed();
  }

  saveApplication() {
    this.applicationService
      .update(this.application.id, this.application)
      .subscribe(data => this.router.navigate(['applications']));
  }

  sendQualification() {
    this.applicationService
      .updateStatus(this.application.id, this.statusTypesEnum.InProcess)
      .subscribe(data => {
        this.application.status = this.statusTypesEnum.InProcess,
          this.router.navigate(['applications'])
      });
  }

  isEditAllowed() {
    this.isAuthor = this.applicationService.isAuthor(this.application.userId);
    let role = JSON.parse(localStorage.getItem('user')).role;

    if ((role == 'Admin') || (this.application.status == 1 && this.isAuthor == true)) {
      this.canEdit = true;
    }
  }

}