import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {HttpClient} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {IClient} from "../../client/IClient";
import {IDeliveryMan} from "../../deliveryman/IDeliveryMan";

@Injectable({
  providedIn: 'root'
})
export class DeliverymanService implements AbstractService {

  baseApiUrl: string = environment.baseApiUrl;
  //удалить после подключения к бэкенду
  private testDeliveryManUrl: string = 'data/deliveryMan.json';

  constructor(private http: HttpClient) {
  }

  getAllEntities(): Observable<IDeliveryMan[]> {
    return this.http.get<Record<string, any>>(this.testDeliveryManUrl).pipe(
      map((data) => {
        const arr: Array<IDeliveryMan> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id)) arr.push(data[id]);
        }
        return arr;
      })
    );
  }

  getEntity(id: number): Observable<IDeliveryMan> {
    return this.http.get<Record<string, any>>(this.testDeliveryManUrl).pipe(
      map((data) => {
        return data[id];
      }))
  }
}
