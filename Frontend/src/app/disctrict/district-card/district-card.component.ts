import {Component, Input} from '@angular/core';
import {IDistrict} from "../IDistrict";
import {Router} from "@angular/router";

@Component({
  selector: 'app-district-card',
  templateUrl: './district-card.component.html',
  styleUrls: ['./district-card.component.css']
})
export class DistrictCardComponent {
  @Input() district: IDistrict;

  constructor(private route: Router) {
  }

  goToDetail() {
    this.route.navigate([`/district-detail/` + this.district.id.toString()])
  }
}
