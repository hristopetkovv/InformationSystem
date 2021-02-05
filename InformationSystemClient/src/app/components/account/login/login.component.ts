import { Component, OnInit } from '@angular/core';
import { LoginDto } from 'src/app/models/login.dto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: LoginDto = new LoginDto();
  loggedIn: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  login() {

  }

}
