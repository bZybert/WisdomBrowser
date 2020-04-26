import {Routes} from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { RegisterFormComponent } from './modules/register-form/register-form.component';
import { LoginFormComponent } from './modules/login-form/login-form.component';
import { ArticleCardComponent } from './modules/article-card/article-card.component';
import { VideoCardComponent } from './modules/video-card/video-card.component';
import { ProfileCardComponent } from './modules/profile-card/profile-card.component';
import { AuthGuard } from './core/guards/auth.guard';

export const appRoutes : Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterFormComponent },
  { path: 'login', component: LoginFormComponent },
  { path: 'articles', component: ArticleCardComponent, canActivate: [AuthGuard] },
  { path: 'videos', component: VideoCardComponent, canActivate: [AuthGuard] },
  { path: 'profile', component: ProfileCardComponent, canActivate: [AuthGuard]  },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];