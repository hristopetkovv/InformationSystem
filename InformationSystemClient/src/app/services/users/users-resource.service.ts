import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginDto } from '../../models/login.dto';
import { RegisterDto } from '../../models/register.dto';

@Injectable({
  providedIn: 'root'
})
export class UsersResource {

  constructor(private http: HttpClient) { }

  getUserById(id: number): Observable<any> {
    return this.http.get(`api/Users/${id}`);
  }

  createUser(user: RegisterDto): Observable<any> {
    return this.http.post('api/account/register', user);
  }

  loginUser(dto: LoginDto): Observable<any> {
    return this.http.post('api/account/login', dto);
  }

}