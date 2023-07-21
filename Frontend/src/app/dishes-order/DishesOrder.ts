import {IBase} from "../base/IBase";

export class DishesOrder implements IBase{
  Id: number;
  DishesId: number;
  OrderId?: number;
  Count: number;
}
