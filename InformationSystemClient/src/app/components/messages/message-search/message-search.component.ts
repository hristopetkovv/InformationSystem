import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MessageStatus } from 'src/app/enums/messageStatus';
import { MesageSearchDto } from 'src/app/models/search/message-search.dto';

@Component({
  selector: 'message-search',
  templateUrl: './message-search.component.html',
  styleUrls: ['./message-search.component.css']
})
export class MessageSearchComponent implements OnInit {
  @Output() search: EventEmitter<any> = new EventEmitter();
  @Output() clearSearch: EventEmitter<any> = new EventEmitter();

  messageEnum = MessageStatus;

  constructor(public messageFilter: MesageSearchDto) { }

  ngOnInit(): void {
  }

  clear() {
    this.messageFilter = new MesageSearchDto();
    this.clearSearch.emit(this.messageFilter);
  }
}
