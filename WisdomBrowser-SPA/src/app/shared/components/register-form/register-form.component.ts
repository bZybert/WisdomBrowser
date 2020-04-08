import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { AlertifyService } from 'src/app/core/services/alertify.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  @Output() cancelRegisterMode = new EventEmitter();
  model:any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register(){
    this.authService.register(this.model).subscribe(() => {
      console.log(this.model)
      this.alertify.success('Registration ended with success!');
    }, error => {
      console.log(this.model);
      this.alertify.error('Fail');
    })
  }

  cancelRegistration(){
    this.cancelRegisterMode.emit(false);
  }
}
