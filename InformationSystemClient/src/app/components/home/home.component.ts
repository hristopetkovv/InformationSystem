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
  show: boolean = false;
  postStatus = PostStatus;

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

  addPost() {
    this.postService.addPost(this.post)
      .subscribe(data => {
        this.checkDate(data),
          this.show = false,
          this.post = new PostModel()
      });
  }

  editPost(currentPost: PostModel) {
    this.postService.updatePost(currentPost.id, currentPost)
      .subscribe(data => this.post = data);
  }

  updatePostStatus(currentPost: PostModel) {
    this.postService
      .updatePostStatus(currentPost.id, this.postStatus.Saved)
      .subscribe(data => {
        currentPost.status = this.postStatus.Saved
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
