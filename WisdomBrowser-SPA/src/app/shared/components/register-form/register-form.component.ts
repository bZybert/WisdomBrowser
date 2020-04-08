import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  @Output() cancelRegisterMode = new EventEmitter();
  model:any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register(){
    this.authService.register(this.model).subscribe(() => {
      console.log(this.model)
      console.log('Registration ended with success!');
    }, error => {
      console.log(this.model);
      console.log(error);
    })
  }

  cancelRegistration(){
    this.cancelRegisterMode.emit(false);
  }
}
