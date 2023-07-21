import { Injectable } from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {map, Observable} from "rxjs";
import {IBase} from "../../base/IBase";
import {HttpClient} from "@angular/common/http";
import {DishesOrder} from "../../dishes-order/DishesOrder";
import {IDish} from "../../dish/IDish";

@Injectable({
  providedIn: 'root'
})
export class DishOrderService implements  AbstractService {

  constructor(private http: HttpClient) { }

  baseApiUrl: string = environment.baseApiUrl;

  //удалить после подключения к бэкенду
  private testOrderUrl: string = 'data/dish-order.json';
  private currentOrder: Array<DishesOrder>;
  private selectedDishes: Array<IDish> = [];

  getAllEntities(): Observable<DishesOrder[]> {
    return this.http.get<Record<string, any>>(this.testOrderUrl).pipe(
      map((data) => {
        const arr: Array<DishesOrder> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id)) arr.push(data[id]);
        }
        return arr;
      })
    );
  }

  getEntity(id: number): Observable<DishesOrder> {
    return this.http.get<Record<string, any>>(this.testOrderUrl).pipe(
      map((data) => {
        return data[id];
      }))
  }

  getCurrentOrder(): Array<DishesOrder> {
    return this.currentOrder || new Array<DishesOrder>();
  }

  updateCurrentOrder(dishesOrder: DishesOrder) {
    if (!this.currentOrder)
      this.currentOrder = new Array<DishesOrder>();
    this.currentOrder.push(dishesOrder);
  }

  getSelectedDishes(): Array<IDish>{
    return this.selectedDishes;
  }

  updateSelectedDishes(dish: IDish) {
    this.selectedDishes.push(dish);
  }
}
