import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/header/header.component';
import { NavComponent } from './core/header/nav/nav.component';
import { AuthService } from './core/services/auth.service';
import { HomeComponent } from './shared/components/home/home.component';
import { RegisterFormComponent } from './shared/components/register-form/register-form.component';
import { ErrorInterceptorProvider } from './core/services/error.interceptor';
import { AlertifyService } from './core/services/alertify.service';

const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterFormComponent }

];

@NgModule({
  declarations: [
    AppComponent
    , HeaderComponent
    , RegisterFormComponent
    , NavComponent
    , HomeComponent
  ],
  imports: [
    BrowserModule
    , HttpClientModule
    , RouterModule.forRoot(appRoutes)
    , FormsModule
  ],
  providers: [AuthService, ErrorInterceptorProvider, AlertifyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
