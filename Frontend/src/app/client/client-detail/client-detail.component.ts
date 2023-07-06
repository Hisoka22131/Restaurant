import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {IClient} from "../IClient";
import {ClientService} from "../../services/client.service";

@Component({
  selector: 'app-client-detail',
  templateUrl: './client-detail.component.html',
  styleUrls: ['./client-detail.component.css']
})
export class ClientDetailComponent implements OnInit {
  public clientId: number;
  public Client: IClient = {
    Id: 0,
    DiscountPercentage: 0,
    FirstName: "",
    LastName: "",
    PhoneNumber: "",
    Birthday: "",
    City: "",
    Address: "",
    PassportSeries: ""
  };

  constructor(private route: ActivatedRoute, private router: Router, private clientService: ClientService) {
    //преобразуем в Number '+*'
    this.clientId = +this.route.snapshot.params['id'];
    this.clientService.getClient(this.clientId)
      .subscribe(c =>
          this.Client = c
      );
  }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params) => {
        //меняем наш id при переходе на другие страницы
        this.clientId = +params['id']
      });
  }
}
