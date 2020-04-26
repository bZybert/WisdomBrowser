import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/http/user/user.service';
import { UserProfile } from 'src/app/shared/models/userProfile';

@Component({
  selector: 'app-profile-card',
  templateUrl: './profile-card.component.html',
  styleUrls: ['./profile-card.component.css']
})
export class ProfileCardComponent implements OnInit {
  user: UserProfile;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getProfileData();
  }

  getProfileData(){
    this.userService.getUser().subscribe(response => {
      this.user = response;
      console.log(response);
    }, error => {
      console.log(error);
    })
  }

}
