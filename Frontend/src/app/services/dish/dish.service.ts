import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {map, Observable} from "rxjs";
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
    return this.http.get<Record<string, any>>(this.testDishUrl).pipe(
      map((data) => {
        const arr: Array<IDish> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id)) arr.push(data[id]);
        }
        return arr;
      })
    );
  }

  getEntity(id: number): Observable<IDish> {
    return this.http.get<Record<string, any>>(this.testDishUrl).pipe(
      map((data) => {
        return data[id];
      }))
  }
}
