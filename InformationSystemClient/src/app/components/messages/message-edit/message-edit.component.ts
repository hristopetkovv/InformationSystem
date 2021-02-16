import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PostModel } from 'src/app/models/post.model';
import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'message-edit',
  templateUrl: './message-edit.component.html',
  styleUrls: ['./message-edit.component.css']
})
export class MessageEditComponent implements OnInit {
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
