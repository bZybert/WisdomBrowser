import { Component, OnInit } from '@angular/core';
import { TedApiService } from 'src/app/core/http/tedApi/ted-api.service';
import { Video } from 'src/app/shared/models/video';
import { DomSanitizer } from '@angular/platform-browser';
import { UserService } from 'src/app/core/http/user/user.service';


@Component({
  selector: 'app-video-card',
  templateUrl: './video-card.component.html',
  styleUrls: ['./video-card.component.css']
})
export class VideoCardComponent implements OnInit {
  videos: Video[] = [];
  searchedVideos: Video[] = [];
  description: string;
  isLoaded: boolean = false;
  constructor(private tedApi: TedApiService, private sanitizer: DomSanitizer, private userService: UserService) { }

  ngOnInit() {
    this.baseVideoContent();
  }
  ngAfterViewInit(){
    this.isLoaded = true;
  }
  addVideo(name: string, youTubeId: string){
    this.userService.addVideo();
  }

  findVideo(){
    console.log(this.description);
    this.tedApi.findVideos(this.description).subscribe(resp => {
      this.videos = resp;
      }, error => {
        console.log(error);
      });
  }

  bypassSecurityTrustResourceUrl(videoURL: string){
    return this.sanitizer.bypassSecurityTrustResourceUrl(videoURL);
  }

  urlAdaptToDisplay(urlToAdapt: string){
    let result = urlToAdapt.replace("watch?v=", "embed/");
    console.log(result);
    return result;
  }

  baseVideoContent(){
    this.tedApi.getBaseVideoContentData().subscribe(resp => {
    this.videos = resp;
    }, error => {
      console.log(error);
    });
  }
}
