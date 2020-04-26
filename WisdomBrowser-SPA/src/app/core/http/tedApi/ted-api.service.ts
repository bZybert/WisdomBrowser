import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Article } from 'src/app/shared/models/article';
import { Video } from 'src/app/shared/models/video';

@Injectable({
  providedIn: 'root'
})
export class TedApiService {
  baseUrl = 'https://bestapi-ted-v1.p.rapidapi.com/';

constructor(private http: HttpClient) { }

getBaseArticlesContentData(){
  return this.http.get<{[key: number]: Article}>('https://bestapi-ted-v1.p.rapidapi.com/transcriptFreeText?size=3&text=amazing%20talk', {
    headers: new HttpHeaders({
      'x-rapidapi-host': 'bestapi-ted-v1.p.rapidapi.com',
      'x-rapidapi-key': 'ba8ac2661bmshae102ee23e1fdd1p196a63jsnb03f6e766f21'
    })
  }).pipe(map(response => {
    const respArray: Article[] = [];
    for (const key in response) {
      if (response.hasOwnProperty(key)) {
        respArray.push(response[key]);
        
      }
      console.log(respArray);
      return respArray;
    }
  }));
}

findArticles(text: string){
  let searchParams = new HttpParams();
  searchParams = searchParams.append('text', text);
  searchParams = searchParams.append('size', '3');

  return this.http.get<{[key: number]: Article}>(this.baseUrl + 'transcriptFreeText', {
    headers: new HttpHeaders({
      'x-rapidapi-host': 'bestapi-ted-v1.p.rapidapi.com',
      'x-rapidapi-key': 'ba8ac2661bmshae102ee23e1fdd1p196a63jsnb03f6e766f21'
      //'accept': 'application/json'
    }),
    params: searchParams
  }).pipe(map(response => {
    const respArray: Article[] = [];
    for (const key in response) {
      if (response.hasOwnProperty(key)) {
        respArray.push(response[key]);
        
      }
      console.log(respArray);
      return respArray;
    }
  }));
}

getBaseVideoContentData(){
  let searchParams = new HttpParams();
  searchParams = searchParams.append('description', 'address climate change');
  searchParams = searchParams.append('size', '2');

  return this.http.get<{[key: number]: Video}>('https://bestapi-ted-v1.p.rapidapi.com/talksByDescription?size=3&description=address%20climate%20change', {
    headers: new HttpHeaders({
      'x-rapidapi-host': 'bestapi-ted-v1.p.rapidapi.com',
      'x-rapidapi-key': 'ba8ac2661bmshae102ee23e1fdd1p196a63jsnb03f6e766f21'
    })
  }).pipe(map(response => {
    const respArray: Video[] = [];
    for (const key in response) {
      if (response.hasOwnProperty(key)) {
        respArray.push(response[key]);
        
      }
      console.log(respArray);
      return respArray;
    }
  }));
}

findVideos(description: string){
  let searchParams = new HttpParams();
  searchParams = searchParams.append('name', description);
  //searchParams = searchParams.append('size', '3');

  return this.http.get<{[key: number]: Video}>('https://bestapi-ted-v1.p.rapidapi.com/talksByName', {
    headers: new HttpHeaders({
      'x-rapidapi-host': 'bestapi-ted-v1.p.rapidapi.com',
      'x-rapidapi-key': 'ba8ac2661bmshae102ee23e1fdd1p196a63jsnb03f6e766f21'
    }),
    params: searchParams
  }).pipe(map(response => {
    const respArray: Video[] = [];
    for (const key in response) {
      if (response.hasOwnProperty(key)) {
        respArray.push(response[key]);
        
      }
      console.log(respArray);
      return respArray;
    }
  }));
}
}
