import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators';

@Injectable({
 providedIn: 'root'
})

export class AuthService {

  baseUrl = 'http://localhost:61634/api/';

    constructor(private http: HttpClient){}

    login(model: any)
    {
        return this.http.post(this.baseUrl + 'checklogin', model).pipe(
         map((response: any) => {
             const user = response;

             if (user) {
               localStorage.setItem('token', user.userId);
               localStorage.setItem('userName', user.name);
             }
         })
        );
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'RegisterUser', model).pipe(
      map((response: any) => {
        response
      })
    );
  }
}
