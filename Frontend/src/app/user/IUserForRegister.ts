import {IBase} from "../base/IBase";

export interface IUserForRegister extends IBase {
  email: string;
  name: string;
  password: string;
}
