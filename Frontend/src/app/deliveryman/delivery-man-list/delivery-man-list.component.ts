import {Component, OnInit} from '@angular/core';
import {IDeliveryMan} from "../IDeliveryMan";
import {DeliverymanService} from "../../services/deliveryman/deliveryman.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {CreateDeliveryManModalComponent} from "../create-delivery-man-modal/create-delivery-man-modal.component";
import {AlertifyService} from "../../services/view/alertify.service";

@Component({
  selector: 'app-delivery-man-list',
  templateUrl: './delivery-man-list.component.html',
  styleUrls: ['./delivery-man-list.component.css']
})
export class DeliveryManListComponent implements OnInit {

  deliveryMans: Array<IDeliveryMan> = [];

  constructor(private deliverymanService: DeliverymanService,
              private modalService: NgbModal,
              private alertifyService: AlertifyService) {
  }

  ngOnInit(): void {
    this.getDeliveryMans();
  }

  getDeliveryMans(){
    this.deliverymanService.getAllEntities()
      .subscribe(data => {
        this.deliveryMans = data
      })
  }

  openModal() {
    const modalRef = this.modalService.open(CreateDeliveryManModalComponent, {centered: true});
    modalRef.result.then(
      (result) => {
       this.getDeliveryMans();
      },
      (reason) => {
        this.alertifyService.success("Успешно сохранено");
      }
    );
  }

}
