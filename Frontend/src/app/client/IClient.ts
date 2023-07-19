import {IBase} from "../base/IBase";

export interface IClient extends IBase {
  DiscountPercentage: number,
  FirstName: string,
  LastName: string,
  PhoneNumber: string,
  Birthday: string,
  City: string,
  Address: string,
  PassportSeries: string
}