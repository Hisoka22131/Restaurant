import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {NavBarComponent} from './nav-bar/nav-bar.component';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {HomePageComponent} from './home-page/home-page.component';
import { ClientListComponent } from './client/client-list/client-list.component';
import {ClientService} from "./services/client/client.service";
import { ClientCardComponent } from './client/client-card/client-card.component';
import { ClientDetailComponent } from './client/client-detail/client-detail.component';
import {AlertifyService} from "./services/view/alertify.service";
import {FormService} from "./services/view/form.service";
import { DishListComponent } from './dish/dish-list/dish-list.component';
import {DishService} from "./services/dish/dish.service";
import { DishCardComponent } from './dish/dish-card/dish-card.component';
import { DishDetailComponent } from './dish/dish-detail/dish-detail.component';
import { DistrictListComponent } from './disctrict/district-list/district-list.component';
import { DistrictCardComponent } from './disctrict/district-card/district-card.component';
import { DistrictDetailComponent } from './disctrict/district-detail/district-detail.component';
import {DistrictService} from "./services/district/district.service";
import { DeliveryManListComponent } from './deliveryman/delivery-man-list/delivery-man-list.component';
import { DeliveryManDetailComponent } from './deliveryman/delivery-man-detail/delivery-man-detail.component';
import { DeliveryManCardComponent } from './deliveryman/delivery-man-card/delivery-man-card.component';
import {DeliverymanService} from "./services/deliveryman/deliveryman.service";
import { SelectBoxComponent } from './base/select-box/select-box.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomePageComponent,
    ClientListComponent,
    ClientCardComponent,
    ClientDetailComponent,
    DishListComponent,
    DishCardComponent,
    DishDetailComponent,
    DistrictListComponent,
    DistrictCardComponent,
    DistrictDetailComponent,
    DeliveryManListComponent,
    DeliveryManDetailComponent,
    DeliveryManCardComponent,
    SelectBoxComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    // TabsModule.forRoot(),
  ],
  // сервисы
  providers: [
    ClientService,
    DistrictService,
    DishService,
    DeliverymanService,
    AlertifyService,
    FormService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
