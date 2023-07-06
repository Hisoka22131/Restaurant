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
import {ClientService} from "./services/client.service";
import { ClientCardComponent } from './client/client-card/client-card.component';
import { ClientDetailComponent } from './client/client-detail/client-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomePageComponent,
    ClientListComponent,
    ClientCardComponent,
    ClientDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AppRoutingModule
  ],
  // сервисы
  providers: [
    ClientService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
