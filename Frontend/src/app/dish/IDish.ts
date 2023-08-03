import {IBase} from "../base/IBase";

export interface IDish extends IBase {
  name: string;
  type: string;
  taggingDish: number;
  price: number;
}
