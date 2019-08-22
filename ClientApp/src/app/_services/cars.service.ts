import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { Car } from '../_models/car.model';
import { Order } from '../_models/order.model';
import { UserOrders } from '../_models/userOrders.model';

@Injectable({
    providedIn: 'root'
})

export class CarService{
    baseUrl = 'http://localhost:61634/api/';
    carId = 0;
    userId = 0;

    constructor(private http: HttpClient) {}

getUsers(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseUrl + 'cars');
}

getUser(id): Observable<Car> {
    return this.http.get<Car>(this.baseUrl + 'cars/' + id);
}

getCars(ids: string): Observable<Car[]> {
    ids = ids.replace(/(^,)|(,$)/g, '');
    return this.http.get<Car[]>(this.baseUrl + 'cars/?$filter=carId in (' + ids + ')');
}

setOrder(orderDetails: Order): Observable<Order> {
    return this.http.post<Order>(this.baseUrl + 'orders', orderDetails);
}

getUserOrders(data: string): Observable<UserOrders[]> {
   this.userId = Number(localStorage.getItem('token'));
   return this.http.get<UserOrders[]>(this.baseUrl + 'UserOrdersList?userId=' + this.userId +'&orderIdCode='+ data);
}

deleteUserOrder(data: string): Observable<any> {
    
    return this.http.delete<any>(this.baseUrl + 'Orders/' + data);
 }

setCarId(id) {
this.carId = id;
}

getCarId() {
    return this.carId;
}
}

