import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import jwt_decode from 'jwt-decode';
import { UserDto } from 'src/app/models/user.dto';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private readonly token_property = 'access_token';
  loginChanged: Subject<boolean> = new Subject();
  isAdmin: boolean;
  isLoggedInUser = false;

  constructor(
    private http: HttpClient
  ) {
    this.isLoggedInUser = localStorage.getItem('user') !== null && localStorage.getItem('user') !== undefined;
  }

  setCurrentUser(user: UserDto): void {
    localStorage.setItem('user', JSON.stringify(user));
    this.isLoggedInUser = true;
    this.loginChanged.next(true);
  }

  logout(): void {
    localStorage.clear();
    this.isLoggedInUser = false;
    this.loginChanged.next(false);
  }

  isLoggedIn(loggedIn: boolean): void {
    this.isLoggedInUser = loggedIn;
    this.loginChanged.next(loggedIn);
  }

  isLogged(): boolean {
    const token = localStorage.getItem(this.token_property);
    return token && token.length > 0;
  }

  public getToken(): string {
    if (this.isLoggedInUser) {
      const user = JSON.parse(localStorage.getItem('user')) as UserDto;
      const token = user.token;

      return token;
    }

    return null;
  }

  getById(id: number): Observable<any> {
    return this.http.get(`api/Users/${id}`);
  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    }
    catch (Error) {
      return null;
    }
  }

  isUserInRole(role: string) {
    if (role === "Admin") {
      this.isAdmin = true;
    } else if (role === "User") {
      this.isAdmin = false;
    }
  }

  canEdit(userId: number, carCreatorId: number): boolean {
    if (userId == carCreatorId) {
      return true;
    }
    return false;
  }

}
