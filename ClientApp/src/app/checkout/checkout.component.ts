import { Component, OnInit } from '@angular/core';
import { CarsToCart } from 'src/app/_models/carsToCart.model';
import { Globals } from '../_services/globals.service';
import { CarService } from '../_services/cars.service';
import { Car } from '../_models/car.model';
import { Router } from '@angular/router';
import { Order } from '../_models/order.model';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  cartDetails: CarsToCart = new CarsToCart();
  carIdsString: string;
  cars: Car[] = [];
  grandTotal = 0;
  orderDetails: Order = new Order();

  constructor(private globals: Globals, private carService: CarService, private router: Router, private alertify: AlertifyService) {
    
     // console.log(this.carIdsString);


   }

  ngOnInit() {
    // this.globals.updateCartCountFunc.subscribe((value: CarsToCart) => {
    //   // this.orderItemsCount = value.cartItemsCount;
    //   // this.cartDetails.cartItemsCount = value.cartItemsCount;
    //   // this.cartDetails.carId = value.carId;
    //   // console.log(this.cartDetails.carId.toString());
    //   this.carIdsString = value.carId.toString();

    //   //this.loadCarsForCart(this.carIdsString);

    //  });
    this.loadCarsForCart(this.globals.getcaridsstring());

  }

  loadCarsForCart(ids: string) {
    ids = ids.replace(/(^,)|(,$)/g, '');
    console.log(ids);
    this.carService.getCars(ids).subscribe((cars) => {
        this.cars = cars;
        for (let item of this.cars) {
          console.log(item.carPrice);
         this.grandTotal += Number(item.carPrice);
        }
        //console.log(this.cars);
    }, error => {
    });
}

removeItem(data: number) {
  this.grandTotal = 0;
  this.loadCarsForCart(this.globals.getcaridsafterremoveitem(data));
}

createOrder() {
if(this.grandTotal ==0)
{
  this.alertify.error("No items to place Order!!");
}
else
{

this.alertify.confirm("Are you sure you want to place an order?",
() => { 
  this.alertify.success("Order placed successfully") 

  setTimeout(() => {
    for (let item of this.cars) {
       if(this.orderDetails.carId == null)
       {
         this.orderDetails.carId = [];
       }
       this.orderDetails.carId.push(item.carId);
     }
     this.orderDetails.userId = Number(localStorage.getItem('token'));
   
      this.carService.setOrder(this.orderDetails).subscribe((response) => {
         console.log(response);
          this.grandTotal = 0;
          this.globals.clearCartDetails();
          this.loadCarsForCart('');
         
         this.router.navigate(['/orders']);
       });
   }, 2000);
});
  
}
  


}
}
