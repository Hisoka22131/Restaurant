import {Injectable} from '@angular/core';
import {environment} from "../../../../environments/environments";
import {HttpClient} from "@angular/common/http";
import {IUserForLogin} from "../../user/IUserForLogin";
import {IUserForRegister} from "../../user/IUserForRegister";
import {CookieService} from "ngx-cookie-service";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseApiUrl = environment.baseApiUrl;
  currentUser: IUserForLogin;
  isAuth: boolean = false;

  constructor(private http: HttpClient,
              private cookieService: CookieService) {
    this.isAuth = !!cookieService.get("userId");
  }

  getCurrentUser() {
    return this.currentUser;
  }

  setCurrentUser(user: IUserForLogin){
    this.currentUser = user;
    this.isAuth = !!user;
  }

  getUserId(){
    return Number(this.currentUser.id);
  }

  authUser(user: IUserForLogin) {
    return this.http.post(this.baseApiUrl + '/auth/login', user);
  }

  registerUser(user: IUserForRegister) {
    return this.http.post(this.baseApiUrl + '/auth/register', user);
  }

  logout(){
    return this.http.post(this.baseApiUrl + '/auth/logout', {});
  }

  deleteUserInCookie(){
    this.isAuth = false;
    this.cookieService.delete("userId");
    this.cookieService.delete("userEmail");
  }
}
