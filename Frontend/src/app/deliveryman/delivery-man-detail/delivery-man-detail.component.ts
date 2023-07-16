import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {IClient} from "../../client/IClient";
import {ActivatedRoute, Router} from "@angular/router";
import {ClientService} from "../../services/client/client.service";
import {AlertifyService} from "../../services/view/alertify.service";
import {FormService} from "../../services/view/form.service";
import {IDeliveryMan} from "../IDeliveryMan";
import {DeliverymanService} from "../../services/deliveryman/deliveryman.service";

@Component({
  selector: 'app-delivery-man-detail',
  templateUrl: './delivery-man-detail.component.html',
  styleUrls: ['./delivery-man-detail.component.css']
})
export class DeliveryManDetailComponent implements  OnInit {
  deliveryManForm: FormGroup;
  public deliveryManId: number;
  public deliveryMan: IDeliveryMan = {
    Id: 0,
    DistrictId: 0,
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
    private deliveryManService: DeliverymanService,
    private alertifyService: AlertifyService,
    public formService: FormService) {
    //преобразуем в Number '+*'
    this.deliveryManId = +this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.getDeliveryMan();
    this.initForm();
  }

  getDeliveryMan() {
    this.deliveryManService
      .getEntity(this.deliveryManId)
      .subscribe(c => {
        if (c)
          this.deliveryMan = c;
        if (this.deliveryManForm)
          this.populateForm()
      });
  }

  initForm() {
    this.deliveryManForm = new FormGroup({
      firstName: new FormControl(this.deliveryMan.FirstName, Validators.required),
      lastName: new FormControl(this.deliveryMan.LastName, Validators.required),
      phoneNumber: new FormControl(this.deliveryMan.PhoneNumber, [Validators.required, Validators.minLength(9)]),
      birthday: new FormControl(this.deliveryMan.Birthday, Validators.required),
      city: new FormControl(this.deliveryMan.City, Validators.required),
      address: new FormControl(this.deliveryMan.Address, Validators.required),
      passportSeries: new FormControl(this.deliveryMan.PassportSeries, [Validators.required, Validators.minLength(9)]),
      districtId: new FormControl(this.deliveryMan.DistrictId, Validators.required)
    });
  }

  populateForm() {
    this.deliveryManForm.patchValue({
      firstName: this.deliveryMan.FirstName,
      lastName: this.deliveryMan.LastName,
      phoneNumber: this.deliveryMan.PhoneNumber,
      birthday: this.deliveryMan.Birthday,
      city: this.deliveryMan.City,
      address: this.deliveryMan.Address,
      passportSeries: this.deliveryMan.PassportSeries,
      districtId: this.deliveryMan.DistrictId
    });
  }

  onSubmit() {
    this.alertifyService.message(JSON.parse(this.deliveryManForm.value.toString()));
  }
}
