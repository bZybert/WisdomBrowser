import { Component, OnInit, TemplateRef  } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { AlertifyService } from '../../services/alertify.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  radioTags: any = [];
  isUserLogged = false;
  modalRef: BsModalRef;
  constructor(private authService: AuthService, private alertify: AlertifyService, private modalService: BsModalService) { }

  ngOnInit() {
    this.isLogged();
  }

  login(){
   this.authService.login(this.model).subscribe(next => {
     this.alertify.success('Logged in')
   }, error => {
    this.alertify.error('Fail');
    console.log(error);
   });
   console.log(this.model);
 }

 loggedIn(){
   this.isUserLogged = this.authService.loggedIn();
   console.log(this.authService.loggedIn());
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

openModal(template: TemplateRef<any>) {
  this.modalRef = this.modalService.show(template);
}


}
