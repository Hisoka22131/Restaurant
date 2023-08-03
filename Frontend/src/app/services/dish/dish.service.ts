import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {map, Observable} from "rxjs";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {IDish} from '../../dish/IDish';
import {IDistrict} from "../../disctrict/IDistrict";

@Injectable({
  providedIn: 'root'
})
export class DishService implements AbstractService {

  constructor(private http: HttpClient) {
  }

  baseApiUrl: string = environment.baseApiUrl;
  //удалить после подключения к бэкенду
  private testDishUrl: string = 'data/dishes.json';

  getAllEntities(): Observable<IDish[]> {
    return this.http.get<IDish[]>(this.baseApiUrl + "/dish/get-dishes");
  }

  getEntity(id: number): Observable<IDish> {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.get<IDish>(this.baseApiUrl + "/dish/get-dish/" + id.toString(), httpOptions);
  }

  deleteEntity(id: number){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.delete<IDish>(this.baseApiUrl + "/dish/delete-dish/" + id.toString(), httpOptions)
  }

  postEntity(dish: IDish){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.post<IDish>(this.baseApiUrl + "/dish/send-dish", dish, httpOptions)
  }
}
