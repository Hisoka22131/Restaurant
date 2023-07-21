import {Component, Input} from '@angular/core';
import {DishOrderService} from "../../services/dish-order/dish-order.service";
import {IDish} from "../IDish";
import {DishesOrder} from "../../dishes-order/DishesOrder";

@Component({
  selector: 'app-dish-card',
  templateUrl: './dish-card.component.html',
  styleUrls: ['./dish-card.component.css']
})
export class DishCardComponent {
  @Input() dish: IDish
  isAddingToOrder: boolean = false;

  constructor(private dishOrderService: DishOrderService) {
  }

  onAddToOrder(dish: IDish) {

    this.dishOrderService.updateSelectedDishes(dish);
    this.isAddingToOrder = true;
    const dishOrder = new DishesOrder();
    dishOrder.DishesId = dish.Id;
    dishOrder.Count = 1;
    this.dishOrderService.updateCurrentOrder(dishOrder);
  }
}
