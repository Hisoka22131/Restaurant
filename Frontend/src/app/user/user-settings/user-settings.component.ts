import {Component} from '@angular/core';
import {AlertifyService} from "../../services/view/alertify.service";
import {AuthService} from "../../services/auth/auth.service";

@Component({
  selector: 'app-user-settings',
  templateUrl: './user-settings.component.html',
  styleUrls: ['./user-settings.component.css']
})
export class UserSettingsComponent {

  password: string;

  constructor(private authService: AuthService,
              private alertifyService: AlertifyService) {
  }

  changePassword() {
    this.authService.changePassword(this.password)
      .subscribe(() => this.alertifyService.success("Пароль успешно изменен"),
          error => this.alertifyService.error("При смене пароля произошла ошибка"))
  }

}
