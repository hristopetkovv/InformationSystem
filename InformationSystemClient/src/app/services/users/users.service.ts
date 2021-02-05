import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private readonly token_property = 'access_token';
  loginChanged: Subject<boolean> = new Subject();

  constructor(
    private http: HttpClient
  ) { }

  login(token: string, userId: string): void {
    localStorage.setItem(this.token_property, token);
    localStorage.setItem('userId', userId);
    this.loginChanged.next(true);
  }

  logout(): void {
    localStorage.clear();
    this.loginChanged.next(false);
  }

  isLogged(): boolean {
    const token = localStorage.getItem(this.token_property);
    return token && token.length > 0;
  }

  public getToken(): string {
    return localStorage.getItem('access_token');
  }

  getById(id: number): Observable<any> {
    return this.http.get(`api/Users/${id}`);
  }

  getUserId(): number {
    var decodedToken = this.getDecodedAccessToken(this.getToken());
    return decodedToken['nameid'];
  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    }
    catch (Error) {
      return null;
    }
  }

  canEdit(userId: number, carCreatorId: number): boolean {
    if (userId == carCreatorId) {
      return true;
    }
    return false;
  }

  // editInfo(id: number, user: any): Observable<any> {
  //   return this.http.put(`api/Users/${id}`, user);
  // }

}
