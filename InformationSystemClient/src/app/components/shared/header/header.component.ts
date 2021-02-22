import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  loggedIn: boolean = false;
  isAdmin: boolean;

  constructor(
    private userService: UsersService,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
    this.loggedIn = this.userService.isLoggedInUser;
    this.userService.loginChanged.subscribe(isLoggedIn => {
      this.loggedIn = isLoggedIn;
      this.isAdmin = this.userService.isAdmin();
    });
  }

  logout() {
    this.userService.logout();
    this.loggedIn = false;
    this.router.navigate(['login']);
  }

}