import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {IClient} from "../IClient";
import {ClientService} from "../../services/client/client.service";
import {NgForm} from "@angular/forms";
import {AlertifyService} from "../../services/view/alertify.service";

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

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService,
    private alertifyService: AlertifyService
  ) {
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

  getClient() {
    this.clientService
      .getEntity(this.clientId)
      .subscribe(c => this.client = c);
  }

  onSubmit(Form: NgForm) {
    this.alertifyService.message('ewgewgewggegew')
    // return this.http.post(this.baseApiUrl + '/product/CreateProduct', this.productView)
    //   .subscribe(data => console.log(data))
  }

}
