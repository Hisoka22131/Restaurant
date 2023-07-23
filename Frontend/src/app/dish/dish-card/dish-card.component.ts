import {Component, Input} from '@angular/core';
import {DishOrderService} from "../../services/dish-order/dish-order.service";
import {IDish} from "../IDish";
import {DishOrder} from "../../dishes-order/DishOrder";

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

  onAddToOrder() {
    if (this.isExistsInOrder()) return;
    this.isAddingToOrder = true;
    const dishOrder = new DishOrder();
    dishOrder.DishId = this.dish.Id;
    dishOrder.Count = 1;
    this.dishOrderService.updateSelectedDishes(this.dish);
    this.dishOrderService.updateCurrentOrder(dishOrder);
  }

  isExistsInOrder(): any {
    return this.dishOrderService.getCurrentOrder().find(q => q.DishId === this.dish.Id) || this.isAddingToOrder;
  }
}
