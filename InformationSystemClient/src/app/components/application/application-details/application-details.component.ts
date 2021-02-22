import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StatusType } from 'src/app/enums/statusType';
import { ApplicationDto } from 'src/app/models/application/application.dto';
import { ApplicationService } from 'src/app/services/applications/application.service';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-application-details',
  templateUrl: './application-details.component.html',
  styleUrls: ['./application-details.component.css']
})
export class ApplicationDetailsComponent implements OnInit {
  application = new ApplicationDto();
  canEdit: boolean;
  isApplicationAuthor: boolean;

  statusTypesEnum = StatusType;

  constructor(
    private route: ActivatedRoute,
    private applicationService: ApplicationService,
    private router: Router,
    private userService: UsersService
  ) { }

  ngOnInit(): void {
    this.route.data
      .subscribe((data: any) => this.application = data.application);
    this.isEditAllowed();
  }

  saveApplication() {
    this.applicationService
      .update(this.application.id, this.application)
      .subscribe(() => this.router.navigate(['applications']));
  }

  sendQualification() {
    this.applicationService
      .updateStatus(this.application.id, this.statusTypesEnum.InProcess)
      .subscribe(() => {
        this.application.status = this.statusTypesEnum.InProcess,
          this.router.navigate(['applications'])
      });
  }

  isEditAllowed() {
    this.isApplicationAuthor = this.userService.isApplicationAuthor(this.application.userId);

    if (this.userService.isAdmin() || (this.application.status == 1 && this.isApplicationAuthor == true)) {
      this.canEdit = true;
    }
  }
}