import { Component, Input, OnInit } from '@angular/core';
import { MessageModel } from 'src/app/models/message/message.model';
import { MessageService } from 'src/app/services/message/message.service';

@Component({
  selector: 'message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent implements OnInit {
  messages: MessageModel[];

  constructor(private messageService: MessageService) {
  }

  ngOnInit(): void {
    this.messageService.getMessages()
      .subscribe(data => this.messages = data);
  }

}
