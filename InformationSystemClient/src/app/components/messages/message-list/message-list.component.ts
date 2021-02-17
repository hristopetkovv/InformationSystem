import { Component, Input, OnInit } from '@angular/core';
import { MessageModel } from 'src/app/models/message/message.model';

@Component({
  selector: 'message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent implements OnInit {
  @Input() messages: MessageModel[];
  role: string;

  constructor() {
    let user = JSON.parse(localStorage.getItem('user'));
    if (user != null) {
      this.role = user.role;
    }
  }

  ngOnInit(): void {
  }
}
