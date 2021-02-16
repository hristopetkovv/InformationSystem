import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { PostStatus } from 'src/app/enums/PostStatus';
import { PostModel } from 'src/app/models/post.model';
import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  posts: PostModel[];
  post: PostModel = new PostModel();
  role = JSON.parse(localStorage.getItem('user')).role;

  // postStatus = PostStatus;

  constructor(
    private postService: PostService,
    public datepipe: DatePipe,
  ) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts() {
    this.postService.getPosts()
      .subscribe(data => this.posts = data);
  }
}
