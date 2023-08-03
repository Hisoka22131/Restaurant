import {Component, OnInit} from '@angular/core';
import {DishService} from "../../services/dish/dish.service";
import {IDistrict} from "../IDistrict";
import {DistrictService} from "../../services/district/district.service";

@Component({
  selector: 'app-district-list',
  templateUrl: './district-list.component.html',
  styleUrls: ['./district-list.component.css']
})
export class DistrictListComponent implements OnInit {

  constructor(private districtService: DistrictService) {
  }

  districts: Array<IDistrict> = [];

  ngOnInit(): void {
    this.districtService.getAllEntities()
      .subscribe(data => {
        this.districts = data
      })
  }
}
