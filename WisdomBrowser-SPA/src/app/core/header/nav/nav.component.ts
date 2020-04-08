import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { AlertifyService } from '../../services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  isUserLogged = false;
  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.isLogged();
  }

  login(){
   this.authService.login(this.model).subscribe(next => {
     this.alertify.success('Logged in')
   }, error => {
    this.alertify.error('Fail');
   });
   console.log(this.model);
 }

 loggedIn(){
   const token = localStorage.getItem('token');
   // !!true or false (if token == null return false)
   if (token != null && token.length > 0){
     return true;
   }
   else{
     return !!token;
   }

 }

 loggedOut(){
  localStorage.removeItem('token');
  // !!true or false (if token == null return false)
  console.log('loogedout')
}

isLogged(){
  const token = localStorage.getItem('token');
  // !!true or false (if token == null return false)
  if (token != null && token.length > 0){
    this.isUserLogged = true;
  }
  else{
    this.isUserLogged = false;
  }
}
}
