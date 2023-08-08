import {IBase} from "../base/IBase";

export interface IUserForLogin extends IBase {
  email: string;
  password: string;
}
