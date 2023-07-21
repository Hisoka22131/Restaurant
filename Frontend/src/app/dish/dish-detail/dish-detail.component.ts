import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Router} from "@angular/router";
import {AlertifyService} from "../../services/view/alertify.service";
import {FormService} from "../../services/view/form.service";
import {IDish} from "../IDish";
import {DishService} from "../../services/dish/dish.service";

@Component({
  selector: 'app-dish-detail',
  templateUrl: './dish-detail.component.html',
  styleUrls: ['./dish-detail.component.css']
})
export class DishDetailComponent implements OnInit {

  dishForm: FormGroup;
  public dishId: number;
  public dish: IDish = {
    Id: 0,
    Name: "",
    Type: "",
    TaggingDish: 0,
    Price: 0
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private dishService: DishService,
    private alertifyService: AlertifyService,
    public formService: FormService) {
    //преобразуем в Number '+*'
    this.dishId = +this.route.snapshot.params['id'];
  }

  ngOnInit(): void {
    this.getDish();
    this.initForm();
  }

  getDish() {
    this.dishService
      .getEntity(this.dishId)
      .subscribe(c => {
        if (c)
          this.dish = c;
        if (this.dishForm)
          this.populateForm()
      });
  }

  initForm() {
    this.dishForm = new FormGroup({
      name: new FormControl(this.dish.Name, Validators.required),
      type: new FormControl(this.dish.Type, Validators.required),
      taggingDish: new FormControl(this.dish.TaggingDish, Validators.required)
    });
  }

  populateForm() {
    this.dishForm.patchValue({
      name: this.dish.Name,
      type: this.dish.Type,
      taggingDish: this.dish.TaggingDish
    });
  }

  onSubmit() {
    this.alertifyService.message(JSON.parse(this.dishForm.value.toString()));
  }

}
