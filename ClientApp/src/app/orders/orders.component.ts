import { Component, OnInit } from '@angular/core';
import { CarService } from '../_services/cars.service';
import { UserOrders } from '../_models/userOrders.model';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  userOrders: UserOrders[] = [];
  colorsDiv =['bg-primary','bg-secondary','bg-success','bg-danger','bg-warning','bg-info'];
  colorCount=0;
  constructor(private carsService: CarService, private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.userOrdersFunc('');
  }

  userOrdersFunc(data: string) {
    this.carsService.getUserOrders(data).subscribe((response: UserOrders[]) => {
      this.userOrders = response;
      this.userOrders.forEach((value, k) => {
        
        //value.colorClass = (this.colorsDiv.length - 1) === k ? this.colorsDiv[this.colorCount]
        if(this.colorsDiv.length === this.colorCount)
        {
          this.colorCount = 0;
        }

        this.colorCount++;
        value.colorClass = this.colorsDiv[this.colorCount];
      });
      console.log(this.userOrders);
    });
  }

  deleteOrder(id: string){
    this.alertifyService.confirm("Are you sure you want to delete this Order?",()=>{
      this.carsService.deleteUserOrder(id).subscribe((response:any) =>{
console.log(response);
this.colorCount = 0;
this.userOrdersFunc('');
this.alertifyService.success("Order deleted successfully!!");
    });
     
    });
  }
}
