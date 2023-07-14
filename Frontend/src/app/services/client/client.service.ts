import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {environment} from "../../../../environments/environments";
import {IClient} from "../../client/IClient";
import {AbstractService} from "../abstract/abstract.service";

@Injectable({
  providedIn: 'root'
})
export class ClientService implements AbstractService {

  baseApiUrl: string = environment.baseApiUrl;
  //удалить после подключения к бэкенду
  private testClientUrl: string = 'data/clients.json';

  constructor(private http: HttpClient) {
  }

  getAllEntities(): Observable<IClient[]> {
    return this.http.get<Record<string, any>>(this.testClientUrl).pipe(
      map((data) => {
        const clientsArray: Array<IClient> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id)) clientsArray.push(data[id]);
        }
        return clientsArray;
      })
    );
  }

  getEntity(id: number): Observable<IClient> {
    return this.http.get<Record<string, any>>(this.testClientUrl).pipe(
      map((data) => {
        return data[id];
      }))
  }
}
