import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Car } from '../_models/car.model';

@Injectable({
    providedIn: 'root'
})

export class CarService{
    baseUrl = 'http://localhost:61634/api/';
    carId = 0;

    constructor(private http: HttpClient) {}

getUsers(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseUrl + 'cars');
}

getUser(id): Observable<Car> {
    return this.http.get<Car>(this.baseUrl + 'cars/' + id);
}

setCarId(id) {
this.carId = id;
}

getCarId() {
    return this.carId;
}
}

