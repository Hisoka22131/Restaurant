import {Component, OnInit} from '@angular/core';
import {DishOrderService} from "../../services/dish-order/dish-order.service";
import {IDish} from "../../dish/IDish";
import {DishOrder} from "../../dishes-order/DishOrder";
import {CommonService} from "../../services/common.service";
import {OrderService} from "../../services/order/order.service";
import {AlertifyService} from "../../services/view/alertify.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-create-dish-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {

  selectedDishes: Array<IDish> = [];

  currentOrder: Array<DishOrder> = [];

  constructor(private dishOrderService: DishOrderService,
              private orderService: OrderService,
              private alertifyService: AlertifyService,
              public commonService: CommonService,
              private router: Router) {
    this.selectedDishes = this.dishOrderService.getSelectedDishes();
    this.currentOrder = this.dishOrderService.getCurrentOrder();
  }

  ngOnInit(): void {
  }

  sumDishesPrice(): string {
    if (!this.selectedDishes || !this.currentOrder) return "0";

    return this.currentOrder.reduce((sum, orderItem) => {
      const dish = this.selectedDishes.find(q => q.id === orderItem.dishId);
      const price = dish?.price || 0;
      return sum + price * orderItem.count;
    }, 0).toFixed(1);
  }

  isEmptyArray(): boolean {
    return this.currentOrder.length === 0;
  }

  createOrder() {
    this.orderService.createOrder(this.currentOrder).subscribe(data => {
      this.dishOrderService.setNullDishOrder();
      this.alertifyService.success("Заказ создан")
      this.router.navigate(["/dish-list"])
    });
  }

}
