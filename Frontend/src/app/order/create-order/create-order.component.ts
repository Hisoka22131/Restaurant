import {Component, OnInit} from '@angular/core';
import {DishOrderService} from "../../services/dish-order/dish-order.service";
import {IDish} from "../../dish/IDish";

@Component({
  selector: 'app-create-dish-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {

  selectedDishes: Array<IDish> = [];

  constructor(private dishOrderService: DishOrderService) {
    this.selectedDishes = this.dishOrderService.getSelectedDishes();
  }

  ngOnInit(): void {
  }

  sumDishesPrice(): number {
    if (this.selectedDishes)
      { // @ts-ignore
        return this.selectedDishes.reduce((acc, current) => acc + current.Price, 0);
      }
    return 0;
  }

  createOrder(){
    console.log(this.dishOrderService.getCurrentOrder())
  }

}
