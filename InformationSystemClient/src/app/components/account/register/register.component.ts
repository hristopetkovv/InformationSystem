import { Component, OnInit } from '@angular/core';
import { RegisterDto } from 'src/app/models/register.dto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: RegisterDto = new RegisterDto();
  loggedIn: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  register() {

  }

  cancel() {

  }
}
