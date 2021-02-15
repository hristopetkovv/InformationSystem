import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { StatusType } from 'src/app/enums/statusType';
import { SearchApplicationDto } from 'src/app/models/search-application.dto';

@Component({
  selector: 'application-search',
  templateUrl: './application-search.component.html',
  styleUrls: ['./application-search.component.css']
})
export class ApplicationSearchComponent implements OnInit {
  @Output() search: EventEmitter<any> = new EventEmitter();
  @Output() clearSearch: EventEmitter<any> = new EventEmitter();

  applicationEnum = StatusType;

  constructor(public applicationFilter: SearchApplicationDto) { }

  ngOnInit(): void {
  }

  clear() {
    this.applicationFilter = new SearchApplicationDto();
    this.clearSearch.emit(this.applicationFilter);
  }
}
