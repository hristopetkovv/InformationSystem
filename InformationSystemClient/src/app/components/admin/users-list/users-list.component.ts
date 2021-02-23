import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/enums/role';
import { UserDto } from 'src/app/models/account/user.dto';
import { AdminService } from 'src/app/services/admin/admin.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {
  users: UserDto[] = [];
  userRole = Role;

  constructor(private adminService: AdminService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.adminService.getUsers().subscribe(data => this.users = data);
  }

  makeUserAdmin(user: UserDto, userId: number) {
    this.adminService.makeUserAdmin(userId).subscribe(() => user.role = Role.Admin);
  }
}
