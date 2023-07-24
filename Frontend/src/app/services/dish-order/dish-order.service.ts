import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {map, Observable} from "rxjs";
import {IBase} from "../../base/IBase";
import {HttpClient} from "@angular/common/http";
import {DishOrder} from "../../dishes-order/DishOrder";
import {IDish} from "../../dish/IDish";

@Injectable({
  providedIn: 'root'
})
export class DishOrderService implements AbstractService {

  constructor(private http: HttpClient) {
  }

  baseApiUrl: string = environment.baseApiUrl;

  //удалить после подключения к бэкенду
  private testOrderUrl: string = 'data/dish-order.json';
  private currentOrder: Array<DishOrder>;
  private selectedDishes: Array<IDish> = [];

  getAllEntities(): Observable<DishOrder[]> {
    return this.http.get<Record<string, any>>(this.testOrderUrl).pipe(
      map((data) => {
        const arr: Array<DishOrder> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id)) arr.push(data[id]);
        }
        return arr;
      })
    );
  }

  getEntity(id: number): Observable<DishOrder> {
    return this.http.get<Record<string, any>>(this.testOrderUrl).pipe(
      map((data) => {
        return data[id];
      }))
  }

  getCurrentOrder(): Array<DishOrder> {
    return this.currentOrder || new Array<DishOrder>();
  }

  updateCurrentOrder(dishOrder: DishOrder) {
    if (!this.currentOrder)
      this.currentOrder = new Array<DishOrder>();
    if (this.currentOrder.indexOf(dishOrder) === -1)
      this.currentOrder.push(dishOrder);
  }

  getSelectedDishes(): Array<IDish> {
    return this.selectedDishes || new Array<IDish>();
  }

  updateSelectedDishes(dish: IDish) {
    if (!this.selectedDishes)
      this.selectedDishes = new Array<IDish>();
    if (this.selectedDishes.indexOf(dish) == -1)
      this.selectedDishes.push(dish);
  }

  updateDishOrderCount(id: number, count: number) {
    let dishOrder = this.currentOrder.find(q => q.dishId === id) as DishOrder;
    if (dishOrder)
      dishOrder.count = count;
  }

  removeDishOrder(dish: IDish) {
    if (dish) {
      let dishOrder = this.currentOrder.find(q => q.dishId === dish.id) as DishOrder;
      dishOrder.count = 0;
      this.selectedDishes.splice(this.selectedDishes.indexOf(dish), 1);
      this.currentOrder.splice(this.currentOrder.indexOf(dishOrder), 1);
    }
  }
}
