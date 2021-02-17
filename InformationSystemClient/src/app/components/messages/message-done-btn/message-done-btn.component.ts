import { Component, Input, OnInit } from '@angular/core';
import { MessageStatus } from 'src/app/enums/messageStatus';
import { MessageModel } from 'src/app/models/message/message.model';
import { MessageService } from 'src/app/services/message/message.service';

@Component({
  selector: 'message-done-btn',
  templateUrl: './message-done-btn.component.html',
  styleUrls: ['./message-done-btn.component.css']
})
export class MessageDoneBtnComponent implements OnInit {
  @Input() item: MessageModel;
  messageStatus = MessageStatus;

  constructor(
    private messageService: MessageService
  ) { }

  ngOnInit(): void {
  }

  updateMessageStatus(message: MessageModel) {
    this.messageService
      .updateMessageStatus(message.id, this.messageStatus.Saved)
      .subscribe(data => {
        message.status = this.messageStatus.Saved
      });
  }
}
