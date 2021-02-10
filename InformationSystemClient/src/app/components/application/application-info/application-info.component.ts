import { Component, Input, OnInit } from '@angular/core';
import { ApplicationType } from 'src/app/enums/applicationType';
import { ApplicationDto } from 'src/app/models/application.dto';

@Component({
  selector: 'application-info',
  templateUrl: './application-info.component.html',
  styleUrls: ['./application-info.component.css']
})
export class ApplicationInfoComponent implements OnInit {
  @Input() application: ApplicationDto;
  applicationTypesEnum = ApplicationType;

  constructor() { }

  ngOnInit(): void {
  }

}
