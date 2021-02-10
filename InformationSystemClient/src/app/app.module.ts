import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';
import { FormsModule } from '@angular/forms';
import { ApplicationListingComponent } from './components/application/application-listing/application-listing.component';
import { TokenInterceptorService } from './interceptors/token-interceptor.service';
import { ApplicationCreatingComponent } from './components/application/application-creating/application-creating.component';
import { ApplicationDetailsComponent } from './components/application/application-details/application-details.component';
import { EnumSelectComponent } from './components/application/enum-select/enum-select.component';
import { QualificationInfoComponent } from './components/application/qualification-info/qualification-info.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    NotFoundComponent,
    LoginComponent,
    RegisterComponent,
    ApplicationListingComponent,
    ApplicationCreatingComponent,
    ApplicationDetailsComponent,
    EnumSelectComponent,
    QualificationInfoComponent,
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
