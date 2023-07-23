import {Component, OnInit} from '@angular/core';
import {DishOrderService} from "../../services/dish-order/dish-order.service";
import {IDish} from "../../dish/IDish";
import {DishOrder} from "../../dishes-order/DishOrder";
import {CommonService} from "../../services/common.service";

@Component({
  selector: 'app-create-dish-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {

  selectedDishes: Array<IDish> = [];

  currentOrder: Array<DishOrder> = [];

  constructor(private dishOrderService: DishOrderService,
              public commonService: CommonService) {
    this.selectedDishes = this.dishOrderService.getSelectedDishes();
    this.currentOrder = this.dishOrderService.getCurrentOrder();
  }

  ngOnInit(): void {
  }

  sumDishesPrice(): string {
    if (!this.selectedDishes || !this.currentOrder) return "0";

    return this.currentOrder.reduce((sum, orderItem) => {
      const dish = this.selectedDishes.find(q => q.Id === orderItem.DishId);
      const price = dish?.Price || 0;
      return sum + price * orderItem.Count;
    }, 0).toFixed(1);
  }

  isEmptyArray(): boolean {
    return this.currentOrder.length === 0;
  }

  createOrder() {
    console.log(this.dishOrderService.getCurrentOrder())
  }

}
