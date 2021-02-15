import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PostDto } from 'src/app/models/post.Dto';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  getPosts(): Observable<PostDto[]> {
    return this.http.get<PostDto[]>(`api/post`);
  }

  addPost(post: PostDto): Observable<PostDto[]> {
    return this.http.post<PostDto[]>(`api/post`, post);
  }
}
