import {Component, OnInit} from '@angular/core';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import {DeliverymanService} from "../../services/deliveryman/deliveryman.service";
import {FormService} from "../../services/view/form.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {IDistrict} from "../../disctrict/IDistrict";
import {DistrictService} from "../../services/district/district.service";
import {CreateDeliveryMan} from "../CreateDeliveryMan";

@Component({
  selector: 'app-create-delivery-man-modal',
  templateUrl: './create-delivery-man-modal.component.html',
  styleUrls: ['./create-delivery-man-modal.component.css']
})
export class CreateDeliveryManModalComponent implements OnInit {

  deliveryManForm: FormGroup;
  districts: Array<IDistrict> = [];
  public deliveryMan: CreateDeliveryMan;

  constructor(private modal: NgbModal,
              private deliveryManService: DeliverymanService,
              public formService: FormService,
              private districtService: DistrictService) {
    this.deliveryMan = new CreateDeliveryMan();
  }

  ngOnInit(): void {
    this.initForm();
    this.getDistricts();
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
      id: new FormControl(0),
      email: new FormControl(this.deliveryMan.email, Validators.required),
      password: new FormControl(this.deliveryMan.password, Validators.required),
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

  createDeliveryMan() {
    this.deliveryManService.createEntity(this.deliveryManForm.value)
      .subscribe(data => {
        this.dismiss();
      });
  }

  dismiss() {
    this.modal.dismissAll();
  }
}
