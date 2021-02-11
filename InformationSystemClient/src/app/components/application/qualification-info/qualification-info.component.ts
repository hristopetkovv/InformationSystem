import { Component, Input, OnInit } from '@angular/core';
import { QualificationType } from 'src/app/enums/qualificationType';
import { ApplicationDto } from 'src/app/models/application.dto';
import { QualificationInfo } from 'src/app/models/qualificationInformation.dto';

@Component({
  selector: 'qualification-info',
  templateUrl: './qualification-info.component.html',
  styleUrls: ['./qualification-info.component.css']
})
export class QualificationInfoComponent implements OnInit {
  @Input() application: ApplicationDto;
  @Input() canEdit: boolean;
  qualificationTypesEnum = QualificationType;

  constructor() { }

  ngOnInit(): void {
  }

  createNewQualification() {
    let commentData = {} as QualificationInfo;
    this.application.qualificationInformation.push(commentData);
  }

  removeQualification(index: number) {
    this.application.qualificationInformation.splice(index, 1);
  }

}
