import {Injectable} from '@angular/core';
import {AbstractService} from "../abstract/abstract.service";
import {environment} from "../../../../environments/environments";
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Dish, IDish} from '../../dish/IDish';

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

  getEntity(id: number): Observable<Dish> {
    return this.http.get<Dish>(this.baseApiUrl + "/dish/get-dish/" + id.toString());
  }

  deleteEntity(id: number){
    return this.http.delete<IDish>(this.baseApiUrl + "/dish/delete-dish/" + id.toString())
  }

  postEntity(dish: Dish){
    return this.http.post<Dish>(this.baseApiUrl + "/dish/send-dish", dish)
  }

  getImage(id: number){
    return this.http.get(this.baseApiUrl + "/dish/get-dish-image/" + id.toString(),{ responseType: 'blob' })
  }

  sendImage(dish: any){

    const formData = new FormData();

    formData.append('id', dish.id.toString());
    formData.append('file', dish.file);

    return this.http.post(this.baseApiUrl + "/dish/save-dish-image", formData);
  }
}
