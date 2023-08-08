import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {Observable} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {IDish} from '../../dish/IDish';

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
    return this.http.get<IDish>(this.baseApiUrl + "/dish/get-dish/" + id.toString());
  }

  deleteEntity(id: number){
    return this.http.delete<IDish>(this.baseApiUrl + "/dish/delete-dish/" + id.toString())
  }

  postEntity(dish: IDish){
    return this.http.post<IDish>(this.baseApiUrl + "/dish/send-dish", dish)
  }
}
