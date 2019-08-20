import { Component, OnInit, Input } from '@angular/core';
import { Car } from 'src/app/_models/car.model';
import { Router } from '@angular/router';
import { CarService } from 'src/app/_services/cars.service';

@Component({
  selector: 'app-car-card',
  templateUrl: './car-card.component.html',
  styleUrls: ['./car-card.component.css']
})
export class CarCardComponent implements OnInit {
@Input() car: Car;
cars = Array<Car>();

  constructor(private router: Router, private carService: CarService) { }

  ngOnInit() {
  }

  viewCar(data) {
     this.carService.getUser(data).subscribe((car: Car) => {
      //  this.cars.push(car);
      //  console.log(this.cars);
           },
           error => {

           });
     this.carService.setCarId(data);
     this.router.navigate(['/CarDetails']);
  }

  addCar(data){
    alert(data);
  }


}
