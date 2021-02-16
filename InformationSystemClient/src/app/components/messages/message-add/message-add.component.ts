import { Component, Input, OnInit } from '@angular/core';
import { PostModel } from 'src/app/models/post.model';
import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'message-add',
  templateUrl: './message-add.component.html',
  styleUrls: ['./message-add.component.css']
})
export class MessageAddComponent implements OnInit {

  @Input() posts: PostModel[];
  post: PostModel = new PostModel();
  show: boolean = false;

  constructor(
    private postService: PostService
  ) { }

  ngOnInit(): void {
  }

  addPost() {
    this.postService.addPost(this.post)
      .subscribe(data => {
        this.checkDate(data),
          this.show = false,
          this.post = new PostModel()
      });
  }

  checkDate(data) {
    if (this.isDateBeforeToday(new Date(this.post.startDate))
      && (this.isDateAfterToday(new Date(this.post.endDate))
        || this.post.endDate == null)) {
      this.posts.push(data);
    }
  }

  isDateBeforeToday(date) {
    return new Date(date.toDateString()) <= new Date(new Date().toDateString());
  }

  isDateAfterToday(date) {
    return new Date(date.toDateString()) > new Date(new Date().toDateString());
  }

}
