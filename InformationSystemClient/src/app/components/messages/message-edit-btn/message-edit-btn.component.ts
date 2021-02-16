import { Component, Input, OnInit } from '@angular/core';
import { PostModel } from 'src/app/models/post.model';
import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'message-edit-btn',
  templateUrl: './message-edit-btn.component.html',
  styleUrls: ['./message-edit-btn.component.css']
})
export class MessageEditBtnComponent implements OnInit {
  @Input() item: PostModel;
  post = new PostModel();

  constructor(
    private postService: PostService
  ) { }

  ngOnInit(): void {
  }

  editPost(currentPost: PostModel) {
    console.log('edit');
    // this.postService.updatePost(currentPost.id, currentPost)
    //   .subscribe(data => this.post = data);
  }
}
