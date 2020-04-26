import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { UserProfile } from 'src/app/shared/models/userProfile';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
baseUrl = 'http://localhost:5000/user/';

constructor(private http: HttpClient) { }

addVideo(){
 // return this.http.post()
}
getVideos(){}

addArdicle(){

}
getArticles(){}

getUser(){
  const userId: string = localStorage.getItem('userId');
  console.log(userId);
  let searchParams = new HttpParams();
  searchParams = searchParams.append('userId', userId);
  return this.http.post<UserProfile>(this.baseUrl + 'getUser', userId).pipe(
    map((response: any) => {
      const user: UserProfile = response;
      console.log(response);
      return user;
    })
  );

}



}
