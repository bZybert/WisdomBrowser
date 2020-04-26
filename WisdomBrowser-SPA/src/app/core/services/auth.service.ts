import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from "@auth0/angular-jwt";
import { UserProfile } from 'src/app/shared/models/userProfile';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  //baseUrl = 'https://localhost:44347/auth/';
  baseUrl = 'http://localhost:5000/auth/';

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model)
      .pipe(
        map((response: any) => {
          const user: UserProfile = response;
          console.log(response);
          if (user) {
            localStorage.setItem('token', user.stamp);
            localStorage.setItem('userId', user.id.toString());
          }
        })
      );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model);
  }

  loggedIn(){
    const token = localStorage.getItem('token');
    if(token){
      return true;
    }
    else{
      return false;
    }
  }
}
