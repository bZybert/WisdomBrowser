import { Component, OnInit } from '@angular/core';
import { TedApiService } from 'src/app/core/http/tedApi/ted-api.service';
import { Article } from 'src/app/shared/models/article';

@Component({
  selector: 'app-article-card',
  templateUrl: './article-card.component.html',
  styleUrls: ['./article-card.component.css']
})
export class ArticleCardComponent implements OnInit {
articles: Article[] = [];

  constructor(private tedApi: TedApiService) { }

  ngOnInit() {
    this.baseContent();
  }

  baseContent(){
    this.tedApi.getBaseArticlesContentData().subscribe(resp => {
      this.articles = resp;
      console.log(resp);
    }, error => {
      console.log(error);
    })
  }
}
