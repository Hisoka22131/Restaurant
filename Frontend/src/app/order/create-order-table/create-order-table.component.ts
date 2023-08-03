import {Component, Input} from '@angular/core';
import {IDish} from "../../dish/IDish";
import {DishOrderService} from "../../services/dish-order/dish-order.service";

@Component({
  selector: 'app-create-order-table',
  templateUrl: './create-order-table.component.html',
  styleUrls: ['./create-order-table.component.css']
})
export class CreateOrderTableComponent {
  @Input() dish: IDish;

  quantity: number = 1;

  constructor(public dishOrderService: DishOrderService) {
  }

  updateCount(method: "increment" | "decrement"): void {
    if (method === "increment")
      this.quantity += 1;
    else
      this.quantity -= this.quantity === 1 ? 0 : 1;
    this.dishOrderService.updateDishOrderCount(this.dish.id, this.quantity);
  }
}
