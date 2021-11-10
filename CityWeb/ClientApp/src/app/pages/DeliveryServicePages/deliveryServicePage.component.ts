import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IDeliveryModel,  ICreateDeliveryModel} from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'delivery-service',
  templateUrl: './deliveryServicePage.component.html',
  styleUrls: ['./deliveryServicePage.component.css']
})

export class DeliveryPageComponent {
  
  public createDelivery: ICreateDeliveryModel = {
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
  } as ICreateDeliveryModel;

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


  constructor(private service: DeliveryManagementService) {}

  public incrementDelivery() {
        this.service.createDeliveryCompany(this.createDelivery)
        .subscribe((res: IDeliveryModel) => {
            this.deliveryInfo = res;
        });
    }

}






  


