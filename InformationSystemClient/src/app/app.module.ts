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
import { ApplicationListComponent } from './components/application/application-list/application-list.component';
import { TokenInterceptorService } from './interceptors/token-interceptor.service';
import { ApplicationCreateComponent } from './components/application/application-create/application-create.component';
import { ApplicationDetailsComponent } from './components/application/application-details/application-details.component';
import { EnumSelectComponent } from './components/shared/enum-select/enum-select.component';
import { QualificationInfoComponent } from './components/application/qualification-info/qualification-info.component';
import { ApplicationInfoComponent } from './components/application/application-info/application-info.component';
import { ApplicationSearchComponent } from './components/application/application-search/application-search.component';
import { DatePipe } from '@angular/common';
import { ReportsListComponent } from './components/reports-list/reports-list.component';
import { MessageAddComponent } from './components/messages/message-add/message-add.component';
import { MessageDoneBtnComponent } from './components/messages/message-done-btn/message-done-btn.component';
import { MessageEditComponent } from './components/messages/message-edit/message-edit.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ErrorInterceptorService } from './interceptors/error-interceptor.service';
import { MessagesListAllComponent } from './components/messages/messages-list-all/messages-list-all.component';
import { MessageSearchComponent } from './components/messages/message-search/message-search.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    NotFoundComponent,
    LoginComponent,
    RegisterComponent,
    ApplicationListComponent,
    ApplicationCreateComponent,
    ApplicationDetailsComponent,
    EnumSelectComponent,
    QualificationInfoComponent,
    ApplicationInfoComponent,
    ApplicationSearchComponent,
    ReportsListComponent,
    MessageAddComponent,
    MessageDoneBtnComponent,
    MessageEditComponent,
    MessagesListAllComponent,
    MessageSearchComponent,
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true, },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptorService, multi: true, },
    [DatePipe]
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
