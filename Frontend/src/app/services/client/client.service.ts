import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {map, Observable} from "rxjs";
import {environment} from "../../../../environments/environments";
import {IClient} from "../../client/IClient";
import {AbstractService} from "../abstract/abstract.service";
import {IDistrict} from "../../disctrict/IDistrict";

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
    return this.http.get<IClient[]>(this.baseApiUrl + "/client/get-clients");
  }

  getEntity(id: number): Observable<IClient> {
    return this.http.get<IClient>(this.baseApiUrl + "/client/get-client/" + id.toString())
  }

  deleteEntity(id: number){
    return this.http.delete<IClient>(this.baseApiUrl + "/client/delete-client/" + id.toString())
  }

  postEntity(district: IClient){
    return this.http.post<IClient>(this.baseApiUrl + "/client/send-client", district)
  }
}
