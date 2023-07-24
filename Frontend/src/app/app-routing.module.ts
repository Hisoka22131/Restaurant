import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomePageComponent} from "./home-page/home-page.component";
import {ClientListComponent} from "./client/client-list/client-list.component";
import {ClientDetailComponent} from "./client/client-detail/client-detail.component";
import {DishDetailComponent} from "./dish/dish-detail/dish-detail.component";
import {DishListComponent} from "./dish/dish-list/dish-list.component";
import {DistrictListComponent} from "./disctrict/district-list/district-list.component";
import {DistrictDetailComponent} from "./disctrict/district-detail/district-detail.component";
import {DeliveryManListComponent} from "./deliveryman/delivery-man-list/delivery-man-list.component";
import {DeliveryManDetailComponent} from "./deliveryman/delivery-man-detail/delivery-man-detail.component";
import {CreateOrderComponent} from "./order/create-order/create-order.component";
import {OrderListComponent} from "./order/order-list/order-list.component";
import {LoginFormComponent} from "./login-register/login-form/login-form.component";

const routes: Routes = [
  //хом
  {path: '', component: HomePageComponent},
  {path: 'client-list', component: ClientListComponent},
  {path: 'client-detail/:id', component: ClientDetailComponent},
  {path: 'dish-list', component: DishListComponent},
  {path: 'dish-detail/:id', component: DishDetailComponent},
  {path: 'district-list', component: DistrictListComponent},
  {path: 'district-detail/:id', component: DistrictDetailComponent},
  {path: 'delivery-man-list', component: DeliveryManListComponent},
  {path: 'delivery-man-detail/:id', component: DeliveryManDetailComponent},
  {path: 'create-order', component: CreateOrderComponent},
  {path: 'order-list', component: OrderListComponent},
  {path: 'login', component: LoginFormComponent},
  //в конце
  {path: '**', component: HomePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
