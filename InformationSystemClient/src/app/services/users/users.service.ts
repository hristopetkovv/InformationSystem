import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { UserDto } from 'src/app/models/user.dto';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private readonly token_property = 'access_token';
  loginChanged: Subject<boolean> = new Subject();
  isAdmin: boolean;
  isLoggedInUser = false;

  constructor() {
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

  getUserNames() {
    if (this.isLoggedInUser) {
      const user = JSON.parse(localStorage.getItem('user')) as UserDto;
      const names = {
        FirstName: user.firstName,
        LastName: user.lastName
      };

      return names;
    }

    return null;
  }

  isLoggedIn(loggedIn: boolean): void {
    this.isLoggedInUser = loggedIn;
    this.loginChanged.next(loggedIn);
  }

  isLogged(): boolean {
    const token = localStorage.getItem(this.token_property);
    return token && token.length > 0;
  }

  getToken(): string {
    if (this.isLoggedInUser) {
      const user = JSON.parse(localStorage.getItem('user')) as UserDto;
      const token = user.token;

      return token;
    }

    return null;
  }

}
