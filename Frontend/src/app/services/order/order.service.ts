import { Injectable } from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {Observable} from "rxjs";
import {IBase} from "../../base/IBase";
import {environment} from "../../../../environments/environments";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {IDistrict} from "../../disctrict/IDistrict";
import {DishOrder} from "../../dishes-order/DishOrder";

@Injectable({
  providedIn: 'root'
})
export class OrderService implements AbstractService  {

  constructor(private http: HttpClient) {
  }

  baseApiUrl: string = environment.baseApiUrl;

  getAllEntities(): Observable<IBase[]> {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.get<IBase[]>(this.baseApiUrl + "/order/get-orders", httpOptions);  }

  getEntity(id: number): Observable<IBase> {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.get<IBase>(this.baseApiUrl + "/order/get-order/" + id.toString(), httpOptions)
  }

  createOrder(dishOrders: Array<DishOrder>){
    return this.http.post(this.baseApiUrl + "/order/create-order", dishOrders);
  }
}
