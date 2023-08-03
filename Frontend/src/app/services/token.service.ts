import {Injectable} from '@angular/core';
import {AlertifyService} from "./view/alertify.service";
import {DateTimeService} from "./date-time.service";
import {JwtHelperService} from "@auth0/angular-jwt";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  helper: JwtHelperService;

  constructor(private alertify: AlertifyService,
              private router: Router) {
    this.helper = new JwtHelperService();
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('token') as string;
    if (!token || this.helper.isTokenExpired(token)) {
      return false;
    }
    return true;
  }

  onLogout() {
    localStorage.removeItem('token');
    this.alertify.success('Вы вышли !');
    this.router.navigate(["/dish-list"])
  }
}
