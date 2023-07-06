import {Component, Input} from '@angular/core';
import {IClient} from "../IClient";

@Component({
  selector: 'app-client-card',
  templateUrl: './client-card.component.html',
  styleUrls: ['./client-card.component.css']
})
export class ClientCardComponent {
  @Input() client: any
}
