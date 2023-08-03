import {IBase} from "../base/IBase";

export interface IDeliveryMan extends IBase {
  firstName: string,
  lastName: string,
  phoneNumber: string,
  birthday: string,
  city: string,
  address: string,
  passportSeries: string,
  districtId: number
}
