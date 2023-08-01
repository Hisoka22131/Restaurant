import {Component, Input} from '@angular/core';
import {IDistrict} from "../IDistrict";

@Component({
  selector: 'app-district-card',
  templateUrl: './district-card.component.html',
  styleUrls: ['./district-card.component.css']
})
export class DistrictCardComponent {
  @Input() district: IDistrict;
}
