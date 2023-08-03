import {IBase} from "../base/IBase";

export class DishOrder implements IBase{
  id: number;
  dishId: number;
  count: number;
}
