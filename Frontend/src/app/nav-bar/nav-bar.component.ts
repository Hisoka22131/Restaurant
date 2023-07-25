import {Component} from '@angular/core';
import {AlertifyService} from "../services/view/alertify.service";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  constructor(private alertify: AlertifyService) {
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
}
