import { Component, OnInit } from '@angular/core';
import { FavouriteApiService } from 'src/app/core/http/favouriteApi/favourite-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  constructor(private favouriteApi: FavouriteApiService) { }

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
