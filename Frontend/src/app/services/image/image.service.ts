import {Injectable} from '@angular/core';
import {DishService} from "../dish/dish.service";
import {BehaviorSubject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  private dataSubject = new BehaviorSubject<number>(1);
  data$ = this.dataSubject.asObservable();

  constructor(private dishService: DishService) {
  }

  getImage(id: number) {
    return this.dishService.getImage(id);
  }

  updateImage(id: number){
    this.dataSubject.next(id);
  }
}
