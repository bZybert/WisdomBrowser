import { Component, OnInit } from '@angular/core';
import { FavouriteApiService } from 'src/app/core/http/favouriteApi/favourite-api.service';
import { Video } from 'src/app/shared/models/video';
import { DomSanitizer } from '@angular/platform-browser';
import { UserService } from 'src/app/core/http/user/user.service';
import { VideoToSave } from 'src/app/shared/models/videoToSave';


@Component({
  selector: 'app-video-card',
  templateUrl: './video-card.component.html',
  styleUrls: ['./video-card.component.css']
})
export class VideoCardComponent implements OnInit {
  videos: Video[] = [];
  videoFav: VideoToSave;
  searchedVideos: Video[] = [];
  description: string;
  isLoaded: boolean = false;
  constructor(private favouriteApi: FavouriteApiService, private sanitizer: DomSanitizer, private userService: UserService) { }

  ngOnInit() {
    this.baseVideoContent();
  }
  ngAfterViewInit(){
    this.isLoaded = true;
  }
  addVideo(name: string, youTubeVideoId: string){
    var userId = parseInt(localStorage.getItem('userId'));
    this.videoFav = {userId: userId, youTubeID: youTubeVideoId, name: name};
    this.userService.addVideo(this.videoFav);
  }

  findVideo(){
    console.log(this.description);
    this.favouriteApi.findVideos(this.description).subscribe(resp => {
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
    this.favouriteApi.getBaseVideoContentData().subscribe(resp => {
    this.videos = resp;
    }, error => {
      console.log(error);
    });
  }
}
