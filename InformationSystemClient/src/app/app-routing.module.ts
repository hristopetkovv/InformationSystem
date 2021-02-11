import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';
import { ApplicationCreatingComponent } from './components/application/application-creating/application-creating.component';
import { ApplicationDetailsComponent } from './components/application/application-details/application-details.component';
import { ApplicationListingComponent } from './components/application/application-listing/application-listing.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';
import { AuthGuardService } from './services/authorization/auth-guard-service';
import { ApplicationResolver } from './services/resolvers/application-resolver';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'applications', component: ApplicationListingComponent, canActivate: [AuthGuardService] },
  { path: 'add', component: ApplicationCreatingComponent, canActivate: [AuthGuardService] },
  { path: 'application/:id', component: ApplicationDetailsComponent, resolve: { application: ApplicationResolver }, canActivate: [AuthGuardService] },
  { path: 'profile', component: HomeComponent, canActivate: [AuthGuardService] },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
