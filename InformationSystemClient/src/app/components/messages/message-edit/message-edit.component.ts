import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageModel } from 'src/app/models/message/message.model';
import { MessageService } from 'src/app/services/message/message.service';

@Component({
  selector: 'message-edit',
  templateUrl: './message-edit.component.html',
  styleUrls: ['./message-edit.component.css']
})
export class MessageEditComponent implements OnInit {
  message: MessageModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private messageService: MessageService
  ) { }

  ngOnInit(): void {
    this.route.data
      .subscribe((data: any) => this.message = data.message);
  }

  editMessage(message: MessageModel) {
    this.messageService.updateMessage(message.id, message)
      .subscribe(data => this.router.navigate(['/']));
  }
}
