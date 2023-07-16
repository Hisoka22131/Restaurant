import {IBase} from "../base/IBase";

export interface IDish extends IBase {
  Name: string;
  Type: string;
  TaggingDish: number;
}
