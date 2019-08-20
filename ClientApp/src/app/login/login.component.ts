import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  signup = false;
  constructor(private authService: AuthService,private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {

      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error('Failed to login');
    });
  }

loggedin() {
const token = localStorage.getItem('token');
return !!token;
}

  hideorshowSignIn() {
    this.signup = this.signup ? false: true;
  }

  register() {
    this.authService.register(this.model).subscribe(next => {
      this.hideorshowSignIn();
      this.alertify.success('Registered successfully');
    }, error => {
      this.alertify.error('username already exists!!');
    });
  }
  

//logout(){
//  localStorage.removeItem('token');
//  console.log('Logged out successfully');
//  }
}
