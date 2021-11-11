import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IDeliveryModel } from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'delivery-management',
  templateUrl: './deliveryManagementPage.component.html',
  styleUrls: ['./deliveryManagementPage.component.css']
})

export class DeliveryManagementComponent {

  public deliveryInfo: IDeliveryModel = {
    title: "",
    description: "",
    workSchedule:  {
        startTime: new Date(),
        endTime: new Date(),
    },
    deliveryPrice: {
        value: 0, 
        tax: 0, 
        vat: 0,
    },
  } as IDeliveryModel;

  constructor(private service: DeliveryManagementService){}

  ngOnInit() {
    this.service.showDeliveryCompany()
    .subscribe((res: IDeliveryModel) => {
        this.deliveryInfo = res;
    });
  }
}
