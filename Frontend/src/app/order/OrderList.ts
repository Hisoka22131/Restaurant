import {IBase} from "../base/IBase";

export class OrderList implements IBase {
  id: number;
  number: string;
  price: number;
  clientFullName: string;
  deliveryManFullName: string;
}
