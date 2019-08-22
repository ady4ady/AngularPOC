import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { CarsToCart } from '../_models/carsToCart.model';

@Injectable()
export class Globals {
  cartCount = 0;
 carsToCart: CarsToCart = new CarsToCart();


  updateCartCountFunc: Subject<CarsToCart> = new Subject<CarsToCart>();

  constructor() {
    // this.sidebarVisibilityChange.subscribe((value) => {
    //     this.cartCount = value;
    // });
  }
  updateCartCount(cartIds: number[]) {
    this.cartCount += 1;
    if (this.carsToCart.carId == null) {
        this.carsToCart.carId = [];
    }

    this.carsToCart.carId.push(cartIds[0]);

    this.carsToCart.cartItemsCount = this.cartCount;
    this.updateCartCountFunc.next(this.carsToCart);
}

getcaridsstring() {
   return this.carsToCart.carId.toString();
}

getcaridsafterremoveitem(data: number) {
    this.carsToCart.carId = this.carsToCart.carId.filter(x => x !== data);
    this.cartCount = this.carsToCart.carId.length - 1;
    this.updateCartCount(this.carsToCart.carId);

    return this.carsToCart.carId.toString();
}

clearCartDetails()
{
  this.carsToCart.carId = [];
  this.cartCount = -1;
  this.updateCartCount([]);
}

}

