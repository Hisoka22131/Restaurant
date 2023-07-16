import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {map, Observable} from "rxjs";
import {IDistrict} from "../../disctrict/IDistrict";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class DistrictService implements AbstractService {

  constructor(private http: HttpClient) {
  }

  baseApiUrl: string = environment.baseApiUrl;

  //удалить после подключения к бэкенду
  private testDistrictUrl: string = 'data/district.json';

  getAllEntities(): Observable<IDistrict[]> {
    return this.http.get<Record<string, any>>(this.testDistrictUrl).pipe(
      map((data) => {
        const arr: Array<IDistrict> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id)) arr.push(data[id]);
        }
        return arr;
      })
    );
  }

  getEntity(id: number): Observable<IDistrict> {
    return this.http.get<Record<string, any>>(this.testDistrictUrl).pipe(
      map((data) => {
        return data[id];
      }))
  }
}
