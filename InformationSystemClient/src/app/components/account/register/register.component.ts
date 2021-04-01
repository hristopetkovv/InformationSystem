import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReCaptchaV3Service } from 'ng-recaptcha';
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
  formdata: any;
  reCaptchaToken: string;

  constructor(
    private userResourse: UsersResource,
    private userService: UsersService,
    private router: Router,
    private reCaptcha3: ReCaptchaV3Service) { }

  ngOnInit(): void {
  }

  public register() {
    this.reCaptcha3.execute('importantAction').subscribe(token => {
      this.model.reCaptchaToken = token;
      this.userResourse.createUser(this.model).subscribe((user: UserDto) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.userService.setCurrentUser(user);
          this.router.navigate(['home']);
        }
      }, error => console.log(error));
    })
  }
}
