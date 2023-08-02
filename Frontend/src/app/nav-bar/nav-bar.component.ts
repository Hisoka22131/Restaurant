import {Component} from '@angular/core';
import {AlertifyService} from "../services/view/alertify.service";
import {DishOrderService} from "../services/dish-order/dish-order.service";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  constructor(private alertify: AlertifyService,
              private dishOrderService: DishOrderService) {
  }

  loggedInUser!: string;

  loggedIn() {
    this.loggedInUser = localStorage.getItem('token') as string;
    return this.loggedInUser;
  }

  onLogout() {
    localStorage.removeItem('token');
    this.alertify.success('Вы вышли !');
  }

  getCount(): number {
    return this.dishOrderService.getSelectedDishes().length;
  }
}
