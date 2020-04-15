import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/header/header.component';
import { NavComponent } from './core/header/nav/nav.component';
import { AuthService } from './core/services/auth.service';
import { RegisterFormComponent } from './modules/register-form/register-form.component';
import { ErrorInterceptorProvider } from './core/services/error.interceptor';
import { AlertifyService } from './core/services/alertify.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HomeComponent } from './modules/home/home.component';
import { LoginFormComponent } from './modules/login-form/login-form.component';
import { TedApiService } from './core/http/tedApi/ted-api.service';


const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterFormComponent },
  { path: 'login', component: LoginFormComponent }

];

@NgModule({
  declarations: [
    AppComponent
    , HeaderComponent
    , RegisterFormComponent
    , LoginFormComponent
    , NavComponent
    , HomeComponent
  ],
  imports: [
    BrowserModule
    , HttpClientModule
    , RouterModule.forRoot(appRoutes)
    , FormsModule
    , BrowserAnimationsModule
    , BsDropdownModule.forRoot()
    , ModalModule.forRoot()
  ],
  providers: [AuthService, ErrorInterceptorProvider, AlertifyService, TedApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
