import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { AlertifyService } from 'src/app/core/services/alertify.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {
  @Output() cancelRegisterMode = new EventEmitter();
  model:any = {};
  user: User;
  signupForm: FormGroup;

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.signupForm = new FormGroup({
      'login': new FormControl(null, Validators.required),
      'password': new FormControl(null, [Validators.required, Validators.minLength(6)]),
      'email': new FormControl(null, [Validators.required, Validators.email])
    });
  }

  onSubmit(){
    if (this.signupForm.valid) {
      // Object.assign(target object, value cloned to target object);
      this.user = Object.assign({}, this.signupForm.value);
      console.log(this.user);
      this.authService.register(this.user).subscribe(
        () => {
          this.alertify.success('Registration successfull');
        },
        error => {
          this.alertify.error(error);
        },
        () => {
          // after user successfully registred automaticly login to page
          this.authService.login(this.user).subscribe(() => {
          // redirect user to members page
          //this.router.navigate(['/members']) ;
          });
        }
      );
    }
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
