import { Component, Input, OnInit } from '@angular/core';
import { PostModel } from 'src/app/models/post.model';

@Component({
  selector: 'message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent implements OnInit {
  @Input() posts: PostModel[];
  @Input() role: string;

  constructor() { }

  ngOnInit(): void {
  }
}
