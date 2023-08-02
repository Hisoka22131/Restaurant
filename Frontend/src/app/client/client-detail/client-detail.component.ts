import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {IClient} from "../IClient";
import {ClientService} from "../../services/client/client.service";
import {FormControl, FormGroup, NgForm, Validators} from "@angular/forms";
import {AlertifyService} from "../../services/view/alertify.service";
import {environment} from "../../../../environments/environments";
import {FormService} from "../../services/view/form.service";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-client-detail',
  templateUrl: './client-detail.component.html',
  styleUrls: ['./client-detail.component.css']
})
export class ClientDetailComponent implements OnInit {

  clientForm: FormGroup;
  public clientId: number;
  public client: IClient = {
    id: 0,
    discountPercentage: 0,
    firstName: "",
    lastName: "",
    phoneNumber: "",
    birthday: "",
    city: "",
    address: "",
    passportSeries: ""
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService,
    private alertifyService: AlertifyService,
    public formService: FormService,
    public datePipe: DatePipe) {
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
      id: new FormControl(this.clientId),
      firstName: new FormControl(this.client.firstName, Validators.required),
      lastName: new FormControl(this.client.lastName, Validators.required),
      phoneNumber: new FormControl(this.client.phoneNumber, [Validators.required, Validators.minLength(9)]),
      birthday: new FormControl(this.client.birthday, Validators.required),
      city: new FormControl(this.client.city, Validators.required),
      address: new FormControl(this.client.address, Validators.required),
      passportSeries: new FormControl(this.client.passportSeries, [Validators.required, Validators.minLength(9)]),
      discountPercentage: new FormControl(this.client.discountPercentage, Validators.required)
    });
  }

  populateForm() {
    this.clientForm.patchValue({
      id: this.clientId,
      firstName: this.client.firstName,
      lastName: this.client.lastName,
      phoneNumber: this.client.phoneNumber,
      birthday: this.datePipe.transform(this.client.birthday,'yyyy-MM-dd'),
      city: this.client.city,
      address: this.client.address,
      passportSeries: this.client.passportSeries,
      discountPercentage: this.client.discountPercentage
    });
  }

  postClient() {
    this.clientService.postEntity(this.clientForm.value)
      .subscribe(data => {
        this.alertifyService.success("Сохранение произошло успешно");
      })
  }

  deleteClient() {
    this.clientService.deleteEntity(this.clientId)
      .subscribe(data => {
        this.alertifyService.success("Удаление произошло успешно");
        this.router.navigate(['/client-list']);
      })
  }
}
