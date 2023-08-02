import {Component, Input} from '@angular/core';
import {IDeliveryMan} from "../IDeliveryMan";
import {Router} from "@angular/router";

@Component({
  selector: 'app-delivery-man-card',
  templateUrl: './delivery-man-card.component.html',
  styleUrls: ['./delivery-man-card.component.css']
})
export class DeliveryManCardComponent {

  @Input() deliveryMan: IDeliveryMan

  constructor(private route: Router) {
  }

  goToDetail() {
    this.route.navigate([`/delivery-man-detail/` + this.deliveryMan.id.toString()])
  }
}
