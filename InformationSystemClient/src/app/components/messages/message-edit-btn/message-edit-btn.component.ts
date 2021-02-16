import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PostModel } from 'src/app/models/post.model';
import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'message-edit-btn',
  templateUrl: './message-edit-btn.component.html',
  styleUrls: ['./message-edit-btn.component.css']
})
export class MessageEditBtnComponent implements OnInit {
  post: PostModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService
  ) { }

  ngOnInit(): void {
    this.route.data
      .subscribe((data: any) => this.post = data.post);
  }

  editPost(currentPost: PostModel) {
    this.postService.updatePost(currentPost.id, currentPost)
      .subscribe(data => this.router.navigate(['/']));
  }
}
