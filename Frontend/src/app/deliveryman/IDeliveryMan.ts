import {IBase} from "../base/IBase";

export interface IDeliveryMan extends IBase {
  FirstName: string,
  LastName: string,
  PhoneNumber: string,
  Birthday: string,
  City: string,
  Address: string,
  PassportSeries: string,
  DistrictId: number
}
