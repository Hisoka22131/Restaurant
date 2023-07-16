import {Component} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {IDish} from "../../dish/IDish";
import {ActivatedRoute, Router} from "@angular/router";
import {DishService} from "../../services/dish/dish.service";
import {AlertifyService} from "../../services/view/alertify.service";
import {FormService} from "../../services/view/form.service";
import {IDistrict} from "../IDistrict";
import {DistrictService} from "../../services/district/district.service";

@Component({
  selector: 'app-district-detail',
  templateUrl: './district-detail.component.html',
  styleUrls: ['./district-detail.component.css']
})
export class DistrictDetailComponent {

  districtForm: FormGroup;
  public districtId: number;
  public dish: IDistrict = {
    Id: 0,
    Name: ""
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private districtService: DistrictService,
    private alertifyService: AlertifyService,
    public formService: FormService) {
    //преобразуем в Number '+*'
    this.districtId = +this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.getDistrict();
    this.initForm();
  }

  getDistrict() {
    this.districtService
      .getEntity(this.districtId)
      .subscribe(c => {
        if (c)
          this.dish = c;
        if (this.districtForm)
          this.populateForm()
      });
  }

  initForm() {
    this.districtForm = new FormGroup({
      name: new FormControl(this.dish.Name, Validators.required)
    });
  }

  populateForm() {
    this.districtForm.patchValue({
      name: this.dish.Name
    });
  }

  onSubmit() {
    this.alertifyService.message(JSON.parse(this.districtForm.value.toString()));
  }
}
