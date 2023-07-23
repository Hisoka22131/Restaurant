import {IBase} from "../base/IBase";

export class DishOrder implements IBase{
  Id: number;
  DishId: number;
  OrderId?: number;
  Count: number;
}
