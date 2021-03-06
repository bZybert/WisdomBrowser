import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { FavouriteApiService } from './core/http/favouriteApi/favourite-api.service';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { ArticleCardComponent } from './modules/article-card/article-card.component';
import { VideoCardComponent } from './modules/video-card/video-card.component';
import { ProfileCardComponent } from './modules/profile-card/profile-card.component';
import { appRoutes } from './routes';
import { NavLeftComponent } from './modules/nav-left/nav-left.component';
import { CarouselMainComponent } from './modules/carousel-main/carousel-main.component';

@NgModule({
  declarations: [
    AppComponent
    , HeaderComponent
    , RegisterFormComponent
    , LoginFormComponent
    , NavComponent
    , HomeComponent
    , ArticleCardComponent
    , VideoCardComponent
    , ProfileCardComponent
    , NavLeftComponent
    , CarouselMainComponent
  ],
  imports: [
    BrowserModule
    , HttpClientModule
    , RouterModule.forRoot(appRoutes)
    , FormsModule
    , ReactiveFormsModule
    , BrowserAnimationsModule
    , BsDropdownModule.forRoot()
    , ModalModule.forRoot()
    , CarouselModule.forRoot()
    
  ],
  providers: [AuthService, ErrorInterceptorProvider, AlertifyService, FavouriteApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
