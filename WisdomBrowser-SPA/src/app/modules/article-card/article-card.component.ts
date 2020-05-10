import { Component, OnInit } from '@angular/core';
import { FavouriteApiService } from 'src/app/core/http/favouriteApi/favourite-api.service';
import { Article } from 'src/app/shared/models/article';

@Component({
  selector: 'app-article-card',
  templateUrl: './article-card.component.html',
  styleUrls: ['./article-card.component.css']
})
export class ArticleCardComponent implements OnInit {
articles: Article[] = [];
description: string;

  constructor(private favouriteApi: FavouriteApiService) { }

  ngOnInit() {
    this.baseContent();
  }

  baseContent(){
    this.favouriteApi.getBaseArticlesContentData().subscribe(resp => {
      this.articles = resp;
      console.log(resp);
    }, error => {
      console.log(error);
    })
  }

  findArticle(){
    console.log(this.description);
    this.favouriteApi.findArticles(this.description).subscribe(resp => {
      this.articles = resp;
    });
  }

  addToFavourite(){
    
  }
}
