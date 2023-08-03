import { Injectable } from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {Observable} from "rxjs";
import {environment} from "../../../../environments/environments";
import {HttpClient} from "@angular/common/http";
import {DishOrder} from "../../dishes-order/DishOrder";
import {OrderList} from "../../order/OrderList";

@Injectable({
  providedIn: 'root'
})
export class OrderService implements AbstractService  {

  constructor(private http: HttpClient) {
  }

  baseApiUrl: string = environment.baseApiUrl;

  getAllEntities(): Observable<OrderList[]> {
    return this.http.get<OrderList[]>(this.baseApiUrl + "/order/get-orders",);  }

  getEntity(id: number): Observable<OrderList> {
    return this.http.get<OrderList>(this.baseApiUrl + "/order/get-order/" + id.toString())
  }

  createOrder(dishOrders: Array<DishOrder>){
    return this.http.post(this.baseApiUrl + "/order/create-order", dishOrders);
  }

  getAllOrders(userId: number) {
    return this.http.get<Array<OrderList>>(this.baseApiUrl + "/order/get-all-orders/" + userId.toString());
  }
}
