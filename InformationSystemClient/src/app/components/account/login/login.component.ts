import { Component, OnInit } from '@angular/core';
import { LoginDto } from 'src/app/models/login.dto';
import { Router } from '@angular/router';
import { UsersResource } from 'src/app/services/users/users-resource.service';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: LoginDto = new LoginDto();

  constructor(private userService: UsersService,
    private userResource: UsersResource,
    private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.userResource.loginUser(this.model)
      .subscribe((data) => {
        this.userService.login(data.token, data.userId);
        this.router.navigate(['home']);
      });
  }
}
