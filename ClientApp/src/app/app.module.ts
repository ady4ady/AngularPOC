import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { OrdersComponent } from './orders/orders.component';
import { appRoutes } from './routes';
import { CarService } from './_services/cars.service';
import { CarListComponent } from './cars/car-list/car-list.component';
import { CarCardComponent } from './cars/car-card/car-card.component';
import { CarViewComponent } from './cars/car-view/car-view.component';
import { AlertifyService } from './_services/alertify.service';
import { Globals } from './_services/globals.service';
import { CheckoutComponent } from './checkout/checkout.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavbarComponent,
    HomeComponent,
    OrdersComponent,
    CarListComponent,
    CarCardComponent,
    CarViewComponent,
    CheckoutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [AuthService, CarService, AlertifyService, Globals],
  bootstrap: [AppComponent]
})
export class AppModule { }
