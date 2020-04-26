import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { AlertifyService } from 'src/app/core/services/alertify.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { User } from 'src/app/shared/models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  model: any = {};
  user: User;
  isUserLogged = false;
  loginForm: FormGroup;
  constructor(private authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      'login': new FormControl('', Validators.required),
      'password': new FormControl(null, Validators.required)
    });
  }

  login() {
    if (this.loginForm.valid) {
      // Object.assign(target object, value cloned to target object);
      this.user = Object.assign({}, this.loginForm.value);
      console.log(this.user);
    
    this.authService.login(this.user).subscribe(next => {
      this.alertify.success('Logged in');
    }, error => {
      this.alertify.error('Fail');
      console.log(error);
    }, () => {
      this.router.navigate(['/home']);
    });
    console.log(this.model);
  }
  }


}
