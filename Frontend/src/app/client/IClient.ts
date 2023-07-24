import {IBase} from "../base/IBase";

export interface IClient extends IBase {
  discountPercentage: number,
  firstName: string,
  lastName: string,
  phoneNumber: string,
  birthday: string,
  city: string,
  address: string,
  passportSeries: string
}
