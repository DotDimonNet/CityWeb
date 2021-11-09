import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IDeliveryModel } from 'src/app/models/delivery.models';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'user-profile',
  templateUrl: './userProfilePage.component.html',
  styleUrls: ['./userProfilePage.component.css']
})
export class DeliveryPageComponent implements OnInit {
  public userInfo: IDeliveryModel = {
    title: "Rocket",
    description: "ny take"
    workSchedule:  {
        startTime: new Date(2020,12,21),
        endTime: new Date(2020,12,21),
    },
    deliveryPrice: {
        value: 100, 
        tax: 0, 
        vat: 0,
    },
  } as IDeliveryModel;

  constructor(private service: DeliveryPageComponent) {}

    ngOnInit() {
        this.service.createDeliveryCompany(deliveryCompany: ICreateDeliveryModel)
        .subscribe((res: IDeliveryModel) => {
            this.userInfo = res;
        });
    }
}