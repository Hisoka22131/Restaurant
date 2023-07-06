import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {environment} from "../../../environments/environments";
import {IClient} from "../client/IClient";

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  baseApiUrl: string = environment.baseApiUrl;
  testUrl: string = 'data/clients.json';

  constructor(private http: HttpClient) {
  }

  getAllClients(): Observable<IClient[]> {
    return this.http.get<Record<string, any>>(this.testUrl).pipe(
      map((data) => {
        const clientsArray: Array<IClient> = [];
        for (const id in data) {
          if (data.hasOwnProperty(id)) clientsArray.push(data[id]);
        }
        return clientsArray;
      })
    );
  }

  getClient(id: number): Observable<IClient> {
    return this.http.get<Record<string, any>>(this.testUrl).pipe(
      map((data) => {
        return data[id];
      }))
  }
}
