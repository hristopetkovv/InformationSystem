import { Component, OnInit } from '@angular/core';
import { MessageModel } from 'src/app/models/message/message.model';
import { MesageSearchDto } from 'src/app/models/search/message-search.dto';
import { MessageService } from 'src/app/services/message/message.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [MesageSearchDto]
})
export class HomeComponent implements OnInit {
  messages: MessageModel[];
  message: MessageModel = new MessageModel();

  constructor(
    private messageService: MessageService,
    public messageFilter: MesageSearchDto
  ) { }

  ngOnInit(): void {
    this.getMessages();
  }

  getMessages() {
    this.messageService.getMessagesByFilter(this.messageFilter)
      .subscribe(data => this.messages = data);
  }
}
