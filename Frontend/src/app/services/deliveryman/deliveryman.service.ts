import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {IDeliveryMan} from "../../deliveryman/IDeliveryMan";
import {DatePipe} from "@angular/common";
import {CreateDeliveryMan} from "../../deliveryman/CreateDeliveryMan";

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
    return this.http.get<IDeliveryMan[]>(this.baseApiUrl + "/deliveryMan/get-delivery-mans");
  }

  getEntity(id: number): Observable<IDeliveryMan> {
    return this.http.get<IDeliveryMan>(this.baseApiUrl + "/deliveryMan/get-delivery-man/" + id.toString());
  }

  deleteEntity(id: number){
    return this.http.delete<IDeliveryMan>(this.baseApiUrl + "/deliveryMan/delete-delivery-man/" + id.toString())
  }

  postEntity(deliveryMan: IDeliveryMan){
    return this.http.post<IDeliveryMan>(this.baseApiUrl + "/deliveryMan/send-delivery-man", deliveryMan)
  }

  createEntity(deliveryMan: CreateDeliveryMan){
    return this.http.post<CreateDeliveryMan>(this.baseApiUrl + "/deliveryMan/create-delivery-man", deliveryMan)
  }
}
