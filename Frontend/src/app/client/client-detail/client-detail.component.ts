import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {IClient} from "../IClient";
import {ClientService} from "../../services/client.service";
import {NgForm} from "@angular/forms";

@Component({
  selector: 'app-client-detail',
  templateUrl: './client-detail.component.html',
  styleUrls: ['./client-detail.component.css']
})
export class ClientDetailComponent implements OnInit {
  public clientId: number;
  public client: IClient = {
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
    this.getClient();
  }

  ngOnInit(): void {
    this.route.params.subscribe(
      (params) => {
        //меняем наш id при переходе на другие страницы
        this.clientId = +params['id']
      });
  }

  // Получаем клиента, надо будет переписать т к в будущем буду с бэка получать
  getClient() {
    this.clientService.getAllClients()
      .subscribe(c => this.client = c.find(q => q.Id === this.clientId) as IClient);
  }

  onSubmit(Form: NgForm) {
    // return this.http.post(this.baseApiUrl + '/product/CreateProduct', this.productView)
    //   .subscribe(data => console.log(data))
  }

}
