import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IDeliveryModel,  ICreateDeliveryModel} from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'delivery/create',
  templateUrl: './createDeliveryPage.component.html',
  styleUrls: ['./createDeliveryPage.component.css']
})

export class CreateDeliveryComponent {
  
  public picker: any;
  public createDelivery: ICreateDeliveryModel = {
    title: "",
    description: "",
    deliveryImage: "",
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

  public create() {
        this.service.createDeliveryCompany(this.createDelivery)
        .subscribe((res: IDeliveryModel) => {
            this.deliveryInfo = res;
        });
    }

}






  


