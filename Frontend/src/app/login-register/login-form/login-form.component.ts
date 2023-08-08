import {Component} from '@angular/core';
import {AuthService} from "../../services/auth/auth.service";
import {IUserForLogin} from "../../user/IUserForLogin";
import {AlertifyService} from "../../services/view/alertify.service";
import {Router} from "@angular/router";
import {FormGroup, NgForm} from "@angular/forms";
import {CookieService} from "ngx-cookie-service";

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
  isPasswordVisible: boolean = false;

  constructor(private authService: AuthService,
              private alertifyService: AlertifyService,
              private router: Router,
              private cookieService: CookieService) {
  }

  login(loginForm: NgForm) {
    this.authService.authUser(loginForm.value)
      .subscribe(data => {
        const user = data as IUserForLogin;
        if (user) {
          this.cookieService.set("userId", user.id.toString())
          this.cookieService.set("userEmail", user.email)
          this.alertifyService.success('Вы успешно вошли');
          this.router.navigate(['/']);
          this.authService.setCurrentUser(user);
        }
      });
  }

  togglePasswordVisibility() {
    this.isPasswordVisible = !this.isPasswordVisible;
    const passwordField = document.getElementById('password-field') as HTMLInputElement;
    passwordField.type = this.isPasswordVisible ? 'text' : 'password';
  }

}
