import { Component, OnInit } from '@angular/core';
import { TedApiService } from 'src/app/core/http/tedApi/ted-api.service';
import { TedDescription } from 'src/app/shared/models/tedDescription';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  contentData: TedDescription[];
  constructor(private tedApi: TedApiService) { }

  ngOnInit() {
    //this.baseContentData();
  }


  registerToogle(){
  this.registerMode = true;
  console.log(this.registerMode);
  }

  switchHomeView(registerMode: boolean){
    this.registerMode = registerMode;
    console.log(this.registerMode);
  }
}
