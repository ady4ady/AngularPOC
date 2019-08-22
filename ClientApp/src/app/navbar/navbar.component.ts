import { Component, OnInit } from '@angular/core';
import { CarsToCart } from 'src/app/_models/carsToCart.model';
import { Globals } from '../_services/globals.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  showDialog = false;
  cartDetails: CarsToCart = new CarsToCart();
  orderItemsCount = 0;
  constructor(private globals: Globals) {
    this.orderItemsCount = this.globals.cartCount;
    this.globals.updateCartCountFunc.subscribe((value: CarsToCart) => {
     // this.orderItemsCount = value.cartItemsCount;
     this.cartDetails.cartItemsCount = value.cartItemsCount;
     this.cartDetails.carId = value.carId;
     
    });

   }

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

  toggle() {
    this.showDialog = !this.showDialog;
  }

  isOrderItemCountNotZero() {
    return this.cartDetails.cartItemsCount > 0;
  }
}
