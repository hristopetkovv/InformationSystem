import { Component, Input, OnInit } from '@angular/core';
import { PostStatus } from 'src/app/enums/PostStatus';
import { PostModel } from 'src/app/models/post.model';
import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'message-done-btn',
  templateUrl: './message-done-btn.component.html',
  styleUrls: ['./message-done-btn.component.css']
})
export class MessageDoneBtnComponent implements OnInit {
  @Input() item: PostModel;
  postStatus = PostStatus;

  constructor(
    private postService: PostService
  ) { }

  ngOnInit(): void {
  }

  updatePostStatus(currentPost: PostModel) {
    this.postService
      .updatePostStatus(currentPost.id, this.postStatus.Saved)
      .subscribe(data => {
        currentPost.status = this.postStatus.Saved
      });
  }
}
