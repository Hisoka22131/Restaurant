import {Component, OnInit} from '@angular/core';
import {DishService} from "../../services/dish/dish.service";
import {IDish} from "../IDish";

@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.css']
})
export class DishListComponent implements OnInit {

  constructor(private dishService: DishService) {
  }

  dishes: Array<IDish> = [];

  ngOnInit(): void {
    this.dishService.getAllEntities()
      .subscribe(data => {
        this.dishes = data
      })
  }

}
