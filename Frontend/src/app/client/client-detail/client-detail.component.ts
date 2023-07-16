import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {IClient} from "../IClient";
import {ClientService} from "../../services/client/client.service";
import {FormControl, FormGroup, NgForm, Validators} from "@angular/forms";
import {AlertifyService} from "../../services/view/alertify.service";
import {environment} from "../../../../environments/environments";
import {FormService} from "../../services/view/form.service";

@Component({
  selector: 'app-client-detail',
  templateUrl: './client-detail.component.html',
  styleUrls: ['./client-detail.component.css']
})
export class ClientDetailComponent implements OnInit {

  clientForm: FormGroup;
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
    private alertifyService: AlertifyService,
    public formService: FormService) {
    //преобразуем в Number '+*'
    this.clientId = +this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.getClient();
    this.initForm();
  }

  getClient() {
    this.clientService
      .getEntity(this.clientId)
      .subscribe(c => {
        if (c)
          this.client = c;
        if (this.clientForm)
          this.populateForm()
      });
  }

  initForm() {
    this.clientForm = new FormGroup({
      firstName: new FormControl(this.client.FirstName, Validators.required),
      lastName: new FormControl(this.client.LastName, Validators.required),
      phoneNumber: new FormControl(this.client.PhoneNumber, [Validators.required, Validators.minLength(9)]),
      birthday: new FormControl(this.client.Birthday, Validators.required),
      city: new FormControl(this.client.City, Validators.required),
      address: new FormControl(this.client.Address, Validators.required),
      passportSeries: new FormControl(this.client.PassportSeries, [Validators.required, Validators.minLength(9)]),
      discountPercentage: new FormControl(this.client.DiscountPercentage, Validators.required)
    });
  }

  populateForm() {
    this.clientForm.patchValue({
      firstName: this.client.FirstName,
      lastName: this.client.LastName,
      phoneNumber: this.client.PhoneNumber,
      birthday: this.client.Birthday,
      city: this.client.City,
      address: this.client.Address,
      passportSeries: this.client.PassportSeries,
      discountPercentage: this.client.DiscountPercentage
    });
  }

  onSubmit() {
    this.alertifyService.message(JSON.parse(this.clientForm.value.toString()));
  }
}
