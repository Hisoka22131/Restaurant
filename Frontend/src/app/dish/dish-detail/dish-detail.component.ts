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
    id: 0,
    name: "",
    type: "",
    taggingDish: 0,
    price: 0
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
    if (!this.dishId) return;
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
      id: new FormControl(this.dishId),
      name: new FormControl(this.dish.name, Validators.required),
      type: new FormControl(this.dish.type, Validators.required),
      taggingDish: new FormControl(this.dish.taggingDish, Validators.required)
    });
  }

  populateForm() {
    this.dishForm.patchValue({
      id: this.dishId,
      name: this.dish.name,
      type: this.dish.type,
      taggingDish: this.dish.taggingDish
    });
  }

  postDish() {
    this.dishService.postEntity(this.dishForm.value)
      .subscribe(data => {
        this.alertifyService.success("Сохранение произошло успешно");
      })
  }

  deleteDish() {
    this.dishService.deleteEntity(this.dishId)
      .subscribe(data => {
        this.alertifyService.success("Удаление произошло успешно");
        this.router.navigate(['/dish-list']);
      })
  }
}
