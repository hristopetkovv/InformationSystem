import { Component, OnInit } from '@angular/core';
import { LoginDto } from 'src/app/models/login.dto';
import { Router } from '@angular/router';
import { UsersResource } from 'src/app/services/users/users-resource.service';
import { UsersService } from 'src/app/services/users/users.service';
import { UserDto } from 'src/app/models/user.dto';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: LoginDto = new LoginDto();

  constructor(private userService: UsersService,
    private userResource: UsersResource,
    private router: Router,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
  }

  login() {
    this.userResource.loginUser(this.model)
      .subscribe((user: UserDto) => {
        if (user) {
          this.userService.setCurrentUser(user);
          this.router.navigate(['']);
        }
      }, error => {
        console.log(error);
      });
  }
}
