import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageStatus } from 'src/app/enums/messageStatus';
import { MessageModel } from 'src/app/models/message/message.model';
import { MesageSearchDto } from 'src/app/models/search/message-search.dto';
import { MessageService } from 'src/app/services/message/message.service';

@Component({
  selector: 'messages-list-all',
  templateUrl: './messages-list-all.component.html',
  styleUrls: ['./messages-list-all.component.css'],
  providers: [MesageSearchDto]
})
export class MessagesListAllComponent implements OnInit {
  messages: MessageModel[];
  messageStatus = MessageStatus;


  constructor(
    private messageService: MessageService,
    public messageFilter: MesageSearchDto,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getMessagesByFilter(this.messageFilter);
  }

  getMessagesByFilter(filter: MesageSearchDto) {
    this.messageService
      .getMessagesByFilter(filter)
      .subscribe(data => this.messages = data);
  }

  redirectionToEdit(id: number) {
    this.router.navigate([`/message/${id}`], { replaceUrl: true });
  }
}
