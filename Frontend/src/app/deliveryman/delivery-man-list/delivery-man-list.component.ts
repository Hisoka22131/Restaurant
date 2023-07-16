import {Component, OnInit} from '@angular/core';
import {IDeliveryMan} from "../IDeliveryMan";
import {DeliverymanService} from "../../services/deliveryman/deliveryman.service";

@Component({
  selector: 'app-delivery-man-list',
  templateUrl: './delivery-man-list.component.html',
  styleUrls: ['./delivery-man-list.component.css']
})
export class DeliveryManListComponent implements OnInit {

  deliveryMans: Array<IDeliveryMan> = [];

  constructor(private deliverymanService: DeliverymanService) {
  }

  ngOnInit(): void {
    this.deliverymanService.getAllEntities()
      .subscribe(data => {
        this.deliveryMans = data
      })
  }
}
