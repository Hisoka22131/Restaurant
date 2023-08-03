import {IBase} from "../base/IBase";

export class CreateDeliveryMan implements IBase {
  id: number;
  email: string;
  password: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  city: string;
  address: string;
  passportSeries: string;
  birthday: string;
  districtId: number;
}
