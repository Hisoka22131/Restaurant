import {IBase} from "../base/IBase";

export interface IDish extends IBase {
  name: string;
  type: string;
  taggingDish: number;
  price: number;
}

export class Dish implements IDish{
  id: number;
  name: string;
  price: number;
  taggingDish: number;
  type: string;
}
