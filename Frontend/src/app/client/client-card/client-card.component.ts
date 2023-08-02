import {Component, Input} from '@angular/core';
import {IClient} from "../IClient";
import {Router} from "@angular/router";

@Component({
  selector: 'app-client-card',
  templateUrl: './client-card.component.html',
  styleUrls: ['./client-card.component.css']
})
export class ClientCardComponent {
  @Input() client: IClient
  constructor(private route: Router) {
  }

  goToDetail() {
    this.route.navigate([`/client-detail/` + this.client.id.toString()])
  }
}
