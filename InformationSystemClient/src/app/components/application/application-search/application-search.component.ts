import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StatusType } from 'src/app/enums/statusType';
import { BaseApplicationDto } from 'src/app/models/baseApplication.dto';
import { SearchApplicationDto } from 'src/app/models/search-application.dto';

@Component({
  selector: 'application-search',
  templateUrl: './application-search.component.html',
  styleUrls: ['./application-search.component.css']
})
export class ApplicationSearchComponent implements OnInit {
  @Input() apllicationsList: BaseApplicationDto[];
  @Output() search: EventEmitter<any> = new EventEmitter();

  applicationEnum = StatusType;

  constructor(public applicationFilter: SearchApplicationDto) { }

  ngOnInit(): void {
  }

}
