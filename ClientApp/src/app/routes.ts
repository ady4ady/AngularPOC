import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { OrdersComponent } from './orders/orders.component';
import { CarViewComponent } from './cars/car-view/car-view.component';
import { CheckoutComponent } from './checkout/checkout.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'orders', component: OrdersComponent },
  {path: 'CarDetails', component: CarViewComponent},
  {path: 'cart', component: CheckoutComponent},
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
