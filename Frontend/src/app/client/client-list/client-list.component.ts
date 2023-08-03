import {Component, OnInit} from '@angular/core';
import {ClientService} from "../../services/client/client.service";
import {IClient} from "../IClient";

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  clients: Array<IClient> = [];

  constructor(private clientService: ClientService) {
  }

  ngOnInit(): void {
    this.clientService.getAllEntities()
      .subscribe(data => {
        this.clients = data
      })
  }
}
