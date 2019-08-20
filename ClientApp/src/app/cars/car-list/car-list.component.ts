import { Component, OnInit } from '@angular/core';
import { Car } from '../../_models/car.model';
import { CarService } from '../../_services/cars.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {

  cars: Car[];
  constructor(private carService: CarService) { }

  ngOnInit() {
    this.loadCars();
  }

  loggedin() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  loadCars() {
    this.carService.getUsers().subscribe((cars: Car[]) => {
this.cars = cars;
console.log(this.cars);
    },
    error => {

    });
  }

}
