import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {map, Observable} from "rxjs";
import {IDistrict} from "../../disctrict/IDistrict";
import {HttpClient, HttpHeaders} from "@angular/common/http";

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
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.get<IDistrict[]>(this.baseApiUrl + "/district/get-districts", httpOptions);
  }

  getEntity(id: number): Observable<IDistrict> {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.get<IDistrict>(this.baseApiUrl + "/district/get-district/" + id.toString(), httpOptions)
  }

  deleteEntity(id: number){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.delete<IDistrict>(this.baseApiUrl + "/district/delete-district/" + id.toString(), httpOptions)
  }

  postEntity(district: IDistrict){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };
    return this.http.post<IDistrict>(this.baseApiUrl + "/district/send-district", district, httpOptions)
  }
}
