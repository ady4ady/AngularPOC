import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
 

  constructor() { }

  ngOnInit() {
  }

  loggedin() {
    const token = localStorage.getItem('token');
    return !!token;
  }  

  loggedUserName() {
    const name = localStorage.getItem('userName');
    return name;
  }

  logout() {
    localStorage.removeItem('token');
    console.log('Logged out successfully');
  }
}
