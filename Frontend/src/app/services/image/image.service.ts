import {Injectable} from '@angular/core';
import {DishService} from "../dish/dish.service";

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(private dishService: DishService) {
  }

  getImage(id: number) {
    return this.dishService.getImage(id);
  }
}
