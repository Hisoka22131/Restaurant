import {Component} from '@angular/core';
import {NgForm} from "@angular/forms";
import {AuthService} from "../../services/auth/auth.service";
import {AlertifyService} from "../../services/view/alertify.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent {
  isPasswordVisible: boolean = false;

  constructor(private authService: AuthService,
              private alertifyService: AlertifyService,
              private router: Router) {
  }

  togglePasswordVisibility() {
    this.isPasswordVisible = !this.isPasswordVisible;
    const passwordField = document.getElementById('password-field') as HTMLInputElement;
    passwordField.type = this.isPasswordVisible ? 'text' : 'password';
  }

  register(registerForm: NgForm) {
    console.log(registerForm.value)
    this.authService.registerUser(registerForm.value)
      .subscribe(data => {
          this.alertifyService.success('Register Successful');
          this.router.navigate(['/login']);
      });
  }
}
