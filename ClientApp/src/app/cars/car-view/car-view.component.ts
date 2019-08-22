import { Component, OnInit, Input } from '@angular/core';
import { Car } from 'src/app/_models/car.model';
import { CarService } from 'src/app/_services/cars.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-car-view',
  templateUrl: './car-view.component.html',
  styleUrls: ['./car-view.component.css']
})
export class CarViewComponent implements OnInit {
  // @Input() car: Car;
  carId = 0;
  carDetails: any;
  hasCarDetails = false;
  constructor(private carService: CarService, private router: Router) { }

  ngOnInit() {

    this.getCarDetails();
  }

  getCarDetails() {
    this.carId = this.carService.getCarId();
    if (this.carId > 0) {
    this.carService.getUser(this.carId).subscribe((car: Car) => {
    this.carDetails = car;
    console.log(this.carDetails);
    this.hasCarDetails = true;
         },
         error => {

         });
        }
      }

      redirectToHome() {
        this.router.navigate(['/home']);
      }
}
