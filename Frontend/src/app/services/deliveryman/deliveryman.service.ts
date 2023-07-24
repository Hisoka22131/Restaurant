import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {IDeliveryMan} from "../../deliveryman/IDeliveryMan";
import {DatePipe} from "@angular/common";

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
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.get<IDeliveryMan[]>(this.baseApiUrl + "/deliveryMan/get-deliverymans", httpOptions);
  }

  getEntity(id: number): Observable<IDeliveryMan> {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.get<IDeliveryMan>(this.baseApiUrl + "/deliveryMan/get-deliveryman/" + id.toString(), httpOptions);
  }

  deleteEntity(id: number){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.delete<IDeliveryMan>(this.baseApiUrl + "/deliveryMan/delete-deliveryman/" + id.toString(), httpOptions)
  }

  postEntity(deliveryMan: IDeliveryMan){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.post<IDeliveryMan>(this.baseApiUrl + "/deliveryMan/send-deliveryman", deliveryMan, httpOptions)
  }
}
