import { Component, Input, OnInit } from '@angular/core';
import { PostModel } from 'src/app/models/post.model';

@Component({
  selector: 'message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent implements OnInit {
  @Input() posts: PostModel[];
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
