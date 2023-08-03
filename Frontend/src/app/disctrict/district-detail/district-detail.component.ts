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
  public district: IDistrict = {
    id: 0,
    name: ""
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
    if (!this.districtId) return;
    this.districtService
      .getEntity(this.districtId)
      .subscribe(c => {
        if (c)
          this.district = c;
        if (this.districtForm)
          this.populateForm()
      });
  }

  initForm() {
    this.districtForm = new FormGroup({
      id: new FormControl(this.districtId),
      name: new FormControl(this.district.name, Validators.required)
    });
  }

  populateForm() {
    this.districtForm.patchValue({
      id: this.districtId,
      name: this.district.name
    });
  }

  postDistrict() {
    this.districtService.postEntity(this.districtForm.value)
      .subscribe(data => {
        this.alertifyService.success("Сохранение произошло успешно");
      })
  }

  deleteDistrict() {
    this.districtService.deleteEntity(this.districtId)
      .subscribe(data => {
        this.alertifyService.success("Удаление произошло успешно");
        this.router.navigate(['/district-list']);
      })
  }
}
