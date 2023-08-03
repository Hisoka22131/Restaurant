import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {AlertifyService} from "../../services/view/alertify.service";
import {FormService} from "../../services/view/form.service";
import {IDeliveryMan} from "../IDeliveryMan";
import {DeliverymanService} from "../../services/deliveryman/deliveryman.service";
import {DistrictService} from "../../services/district/district.service";
import {IDistrict} from "../../disctrict/IDistrict";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-delivery-man-detail',
  templateUrl: './delivery-man-detail.component.html',
  styleUrls: ['./delivery-man-detail.component.css']
})
export class DeliveryManDetailComponent implements OnInit {
  deliveryManForm: FormGroup;
  public deliveryManId: number;
  public deliveryMan: IDeliveryMan = {
    id: 0,
    districtId: 0,
    firstName: "",
    lastName: "",
    phoneNumber: "",
    birthday: "",
    city: "",
    address: "",
    passportSeries: ""
  };

  districts: Array<IDistrict> = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private deliveryManService: DeliverymanService,
    private alertifyService: AlertifyService,
    private districtService: DistrictService,
    public formService: FormService,
    private datePipe: DatePipe) {
    //преобразуем в Number '+*'
    this.deliveryManId = +this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.getDeliveryMan();
    this.initForm();
    this.getDistricts();
  }

  getDeliveryMan() {
    if (!this.deliveryManId) return;
    this.deliveryManService
      .getEntity(this.deliveryManId)
      .subscribe(c => {
        if (c)
          this.deliveryMan = c;
        if (this.deliveryManForm)
          this.populateForm();
      });
  }

  getDistricts() {
    this.districtService
      .getAllEntities()
      .subscribe(data => {
        this.districts = data
      });
  }

  initForm() {
    this.deliveryManForm = new FormGroup({
      id: new FormControl(this.deliveryManId),
      firstName: new FormControl(this.deliveryMan.firstName, Validators.required),
      lastName: new FormControl(this.deliveryMan.lastName, Validators.required),
      phoneNumber: new FormControl(this.deliveryMan.phoneNumber, [Validators.required, Validators.minLength(9)]),
      birthday: new FormControl(this.deliveryMan.birthday, Validators.required),
      city: new FormControl(this.deliveryMan.city, Validators.required),
      address: new FormControl(this.deliveryMan.address, Validators.required),
      passportSeries: new FormControl(this.deliveryMan.passportSeries, [Validators.required]),
      districtId: new FormControl(this.deliveryMan.districtId, Validators.required)
    });
  }

  populateForm() {
    this.deliveryManForm.patchValue({
      id: this.deliveryManId,
      firstName: this.deliveryMan.firstName,
      lastName: this.deliveryMan.lastName,
      phoneNumber: this.deliveryMan.phoneNumber,
      birthday: this.datePipe.transform(this.deliveryMan.birthday,'yyyy-MM-dd'),
      city: this.deliveryMan.city,
      address: this.deliveryMan.address,
      passportSeries: this.deliveryMan.passportSeries,
      districtId: this.deliveryMan.districtId
    });
  }

  postDeliveryMan() {
    this.deliveryManService.postEntity(this.deliveryManForm.value)
      .subscribe(data => {
        this.alertifyService.success("Сохранение произошло успешно");
      })
  }

  deleteDeliveryMan() {
    this.deliveryManService.deleteEntity(this.deliveryManId)
      .subscribe(data => {
        this.alertifyService.success("Удаление произошло успешно");
        this.router.navigate(['/delivery-man-list']);
      })
  }
}
