import {Component} from '@angular/core';
import {OrderList} from "../OrderList";
import {OrderService} from "../../services/order/order.service";
import {AuthService} from "../../services/auth/auth.service";

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent {

  orderList: Array<OrderList> = [];

  constructor(private orderService: OrderService,
              private authService: AuthService) {
    this.orderService.getAllOrders(this.authService.getUserId()).subscribe(data => {
      this.orderList = data
    });
  }
}
