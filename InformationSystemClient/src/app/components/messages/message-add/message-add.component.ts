import { Component, Input, OnInit } from '@angular/core';
import { MessageModel } from 'src/app/models/message/message.model';
import { MessageService } from 'src/app/services/message/message.service';

@Component({
  selector: 'message-add',
  templateUrl: './message-add.component.html',
  styleUrls: ['./message-add.component.css']
})
export class MessageAddComponent implements OnInit {
  @Input() messages: MessageModel[];
  message: MessageModel = new MessageModel();

  constructor(
    private messageService: MessageService
  ) { }

  ngOnInit(): void {
  }

  addMesage() {
    this.messageService.addMessage(this.message)
      .subscribe(data => {
        this.checkDate(data),
          this.message = new MessageModel();
      });
  }

  checkDate(data) {
    if (this.isDateBeforeToday(new Date(this.message.startDate))
      && (this.isDateAfterToday(new Date(this.message.endDate))
        || this.message.endDate == null)) {
      this.messages.push(data);
    }
  }

  isDateBeforeToday(date) {
    return new Date(date.toDateString()) <= new Date(new Date().toDateString());
  }

  isDateAfterToday(date) {
    return new Date(date.toDateString()) > new Date(new Date().toDateString());
  }

}
