import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterDto } from 'src/app/models/account/register.dto';
import { UserDto } from 'src/app/models/account/user.dto';
import { UsersResource } from 'src/app/services/users/users-resource.service';
import { UsersService } from 'src/app/services/users/users.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: RegisterDto = new RegisterDto();

  constructor(private userResourse: UsersResource, private userService: UsersService, private router: Router) { }

  ngOnInit(): void {
  }

  register() {
    this.userResourse.createUser(this.model).subscribe((user: UserDto) => {
      if (user) {
        localStorage.setItem('user', JSON.stringify(user));
        this.userService.setCurrentUser(user);
        this.router.navigate(['home']);
      }
    }, error => console.log(error));
  }
}
