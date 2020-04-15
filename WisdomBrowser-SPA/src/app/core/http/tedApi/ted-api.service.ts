import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TedApiService {
  baseUrl = 'https://bestapi-ted-v1.p.rapidapi.com/transcriptById?youtubeId=rDiGYuQicpA';

constructor(private http: HttpClient) { }

getBaseContentData(){
  return this.http.get(this.baseUrl, {
    headers: new HttpHeaders({
      'x-rapidapi-host': 'bestapi-ted-v1.p.rapidapi.com',
      'x-rapidapi-key': 'ba8ac2661bmshae102ee23e1fdd1p196a63jsnb03f6e766f21',
      'accept': 'application/json'
    })
  });
}
}
