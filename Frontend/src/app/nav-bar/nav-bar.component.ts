import {Component} from '@angular/core';
import {DishOrderService} from "../services/dish-order/dish-order.service";
import {TokenService} from "../services/token.service";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  constructor(private dishOrderService: DishOrderService,
              private tokenService: TokenService) {
  }

  loggedIn() {
    return this.tokenService.loggedIn();
  }

  onLogout() {
    this.tokenService.onLogout();
  }

  getCount(): number {
    return this.dishOrderService.getSelectedDishes().length;
  }
}
