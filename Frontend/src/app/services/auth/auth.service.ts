import {Injectable} from '@angular/core';
import {environment} from "../../../../environments/environments";
import {HttpClient} from "@angular/common/http";
import {IUserForLogin} from "../../user/IUserForLogin";
import {IUserForRegister} from "../../user/IUserForRegister";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseApiUrl = environment.baseApiUrl;
  currentUser: IUserForLogin;

  constructor(private http: HttpClient) {
  }

  getCurrentUser() {
    return this.currentUser;
  }

  setCurrentUser(user: IUserForLogin){
    this.currentUser = user;
  }

  authUser(user: IUserForLogin) {
    return this.http.post(this.baseApiUrl + '/auth/login', user);
  }

  registerUser(user: IUserForRegister) {
    return this.http.post(this.baseApiUrl + '/auth/register', user);
  }
}
