import { Component, OnInit } from '@angular/core';
import { MessageModel } from 'src/app/models/message/message.model';
import { MessageService } from 'src/app/services/message/message.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  messages: MessageModel[];
  message: MessageModel = new MessageModel();

  constructor(
    private messageService: MessageService,
  ) {

  }

  ngOnInit(): void {
    this.getMessages();
  }

  getMessages() {
    this.messageService.getMessages()
      .subscribe(data => this.messages = data);
  }
}
