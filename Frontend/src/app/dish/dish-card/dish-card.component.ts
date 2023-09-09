import {Component, Input, OnInit} from '@angular/core';
import {DishOrderService} from "../../services/dish-order/dish-order.service";
import {IDish} from "../IDish";
import {DishOrder} from "../../dishes-order/DishOrder";
import {ImageService} from "../../services/image/image.service";

@Component({
  selector: 'app-dish-card',
  templateUrl: './dish-card.component.html',
  styleUrls: ['./dish-card.component.css']
})
export class DishCardComponent implements OnInit {

  @Input() dish: IDish

  isAddingToOrder: boolean = false;
  imageSrc: string;

  constructor(private dishOrderService: DishOrderService,
              private imageService: ImageService) {
  }

  ngOnInit(): void {

    if (!this.dish.id) return;

    this.imageService.getImage(this.dish.id).subscribe((data: Blob) => {
      const reader = new FileReader();
      reader.onload = () => {
        this.imageSrc = reader.result as string;
      };
      reader.readAsDataURL(data);
    });

  }

  onAddToOrder() {
    if (this.isExistsInOrder()) return;
    this.isAddingToOrder = true;
    const dishOrder = new DishOrder();
    dishOrder.dishId = this.dish.id;
    dishOrder.count = 1;
    this.dishOrderService.updateSelectedDishes(this.dish);
    this.dishOrderService.updateCurrentOrder(dishOrder);
  }

  isExistsInOrder(): any {
    return this.dishOrderService.getCurrentOrder().find(q => q.dishId === this.dish.id) || this.isAddingToOrder;
  }
}
