import {Component, Input} from '@angular/core';
import {IDish} from "../../dish/IDish";

@Component({
  selector: 'app-create-order-table',
  templateUrl: './create-order-table.component.html',
  styleUrls: ['./create-order-table.component.css']
})
export class CreateOrderTableComponent {
  @Input() dish: IDish;

  quantity: number = 0;

  updateCount(): void {
    console.log(this.quantity)
  }
}
