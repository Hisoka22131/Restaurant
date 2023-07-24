import {Component} from '@angular/core';
import {AuthService} from "../../services/auth/auth.service";
import {IUserForLogin} from "../../user/IUserForLogin";
import {AlertifyService} from "../../services/view/alertify.service";
import {Router} from "@angular/router";
import {FormGroup, NgForm} from "@angular/forms";

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
  loginForm: FormGroup;
  user: IUserForLogin = {
    id: 0,
    email: "",
    token: "",
    password: ""
  };

  constructor(private authService: AuthService,
              private alertifyService: AlertifyService,
              private router: Router) {
  }

  login(loginForm: NgForm) {
    this.authService.authUser(loginForm.value)
      .subscribe(data => {
        const user = data as IUserForLogin;
        if (user) {
          console.log(user)
          localStorage.setItem('token', user.token);
          localStorage.setItem('email', user.email);
          this.alertifyService.success('Login Successful');
          this.router.navigate(['/']);
          this.authService.setCurrentUser(user);
        }
      });
  }

}
