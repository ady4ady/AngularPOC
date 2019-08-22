import { Component, OnInit, Input } from '@angular/core';
import { Car } from 'src/app/_models/car.model';
import { Router } from '@angular/router';
import { CarService } from 'src/app/_services/cars.service';
import { Globals } from 'src/app/_services/globals.service';

@Component({
  selector: 'app-car-card',
  templateUrl: './car-card.component.html',
  styleUrls: ['./car-card.component.css']
})
export class CarCardComponent implements OnInit {
 @Input() car: Car;
cars = Array<Car>();
listcarids: number[] = [];
  constructor(private router: Router, private carService: CarService, private globals: Globals) { }

  ngOnInit() {
  }

  viewCar(data) {

     this.carService.setCarId(data);
     this.router.navigate(['/CarDetails']);
  }

  addCar(data) {
    this.listcarids.push(data);
    this.globals.updateCartCount(this.listcarids);
  }


}
