import {Component} from '@angular/core';
import {DishOrderService} from "../services/dish-order/dish-order.service";
import {AuthService} from "../services/auth/auth.service";
import {AlertifyService} from "../services/view/alertify.service";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  constructor(private dishOrderService: DishOrderService,
              private authService: AuthService,
              private alertifyService: AlertifyService) {
  }

  loggedIn() {
    return this.authService.isAuth;
  }

  onLogout() {
    this.authService.logout()
      .subscribe(() => {
        this.alertifyService.success(`До свидания, ${this.authService.getCurrentUser().email}`)
        this.authService.deleteUserInCookie();
      });
  }

  getCount(): number {
    return this.dishOrderService.getSelectedDishes().length;
  }
}
