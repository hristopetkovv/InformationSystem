import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PostModel } from 'src/app/models/post.model';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  getPosts(): Observable<PostModel[]> {
    return this.http.get<PostModel[]>(`api/post`);
  }

  getById(id: number): Observable<PostModel> {
    return this.http.get<PostModel>(`api/post/${id}`);
  }

  addPost(post: PostModel): Observable<PostModel[]> {
    return this.http.post<PostModel[]>(`api/post`, post);
  }

  updatePost(id: number, post: PostModel): Observable<any> {
    return this.http.put(`api/post/${id}`, post);
  }

  updatePostStatus(id: number, status: number): Observable<any> {
    return this.http.put(`api/post/status/${id}`, status);
  }

}
