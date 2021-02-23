import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';
import { UsersListComponent } from './components/admin/users-list/users-list.component';
import { ApplicationCreateComponent } from './components/application/application-create/application-create.component';
import { ApplicationDetailsComponent } from './components/application/application-details/application-details.component';
import { ApplicationListComponent } from './components/application/application-list/application-list.component';
import { HomeComponent } from './components/home/home.component';
import { MessageEditComponent } from './components/messages/message-edit/message-edit.component';
import { MessagesListAllComponent } from './components/messages/messages-list-all/messages-list-all.component';
import { ReportsListComponent } from './components/reports-list/reports-list.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';
import { AuthGuardService } from './services/authorization/auth-guard-service';
import { RoleGuardService } from './services/authorization/role-guard.service';
import { ApplicationResolver } from './services/resolvers/application-resolver';
import { MessageResolver } from './services/resolvers/message-resolver';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin/users', component: UsersListComponent, canActivate: [RoleGuardService], data: { expectedRole: 'Admin' } },
  { path: 'applications', component: ApplicationListComponent, canActivate: [AuthGuardService] },
  { path: 'add', component: ApplicationCreateComponent, canActivate: [AuthGuardService] },
  { path: 'application/:id', component: ApplicationDetailsComponent, resolve: { application: ApplicationResolver }, canActivate: [AuthGuardService] },
  { path: 'reports', component: ReportsListComponent, canActivate: [AuthGuardService] },
  {
    path: 'messages',
    component: MessagesListAllComponent,
    canActivate: [AuthGuardService, RoleGuardService],
    data: {
      expectedRole: 'Admin'
    }
  },
  {
    path: 'message/:id',
    component: MessageEditComponent,
    resolve: { message: MessageResolver },
    canActivate: [AuthGuardService, RoleGuardService],
    data: {
      expectedRole: 'Admin'
    }
  },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
