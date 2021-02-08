import { typeWithParameters } from '@angular/compiler/src/render3/util';
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

  constructor(
    public userService: UsersService,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.loggedIn = this.userService.isLoggedInUser;
    this.userService.loginChanged.subscribe(isLoggedIn => this.loggedIn = isLoggedIn);
  }

  logout() {
    this.userService.logout();
    this.loggedIn = false;
    this.router.navigate(['login']);
  }

}