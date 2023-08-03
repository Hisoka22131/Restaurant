import {IBase} from "../base/IBase";

export interface IUserForRegister extends IBase {
  email: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  city: string;
  address: string;
  passportSeries: string;
  birthday: string;
  password: string;
}
