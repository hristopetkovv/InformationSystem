import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { PostDto } from 'src/app/models/post.Dto';
import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  posts: PostDto[];
  post: PostDto = new PostDto();
  role = JSON.parse(localStorage.getItem('user')).role;
  show: boolean = false;

  constructor(private postService: PostService, public datepipe: DatePipe) { }

  ngOnInit(): void {
    this.getPosts();
  }

  getPosts() {
    this.postService.getPosts()
      .subscribe(data => this.posts = data);
  }

  save() {
    console.log(this.isDateAfterToday(new Date(this.post.startDate)));

    this.postService.addPost(this.post)
      .subscribe(data => {
        if (this.isDateBeforeToday(new Date(this.post.startDate))
          && (this.isDateAfterToday(new Date(this.post.endDate))
            || this.post.endDate == null)) {
          this.posts.push(this.post);
          console.log("pushed");
        }
        this.show = false,
          this.post = new PostDto()
      });
  }

  isDateBeforeToday(date) {
    return new Date(date.toDateString()) <= new Date(new Date().toDateString());
  }

  isDateAfterToday(date) {
    return new Date(date.toDateString()) > new Date(new Date().toDateString());
  }

  isShow() {
    this.show = true;
  }
}
