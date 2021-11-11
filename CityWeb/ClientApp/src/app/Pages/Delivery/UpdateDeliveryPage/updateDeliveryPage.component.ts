import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IDeliveryModel,  IUpdateDeliveryModel} from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'delete/update',
  templateUrl: './updateDeliveryPage.component.html',
  styleUrls: ['./updateDeliveryPage.component.css']
})

export class UpdateDeliveryComponent {
  
    public updateDelivery: IUpdateDeliveryModel = {
      id: "",
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
    } as IUpdateDeliveryModel;

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

  public update() {
        this.service.updateDeliveryCompany(this.updateDelivery)
        .subscribe((res: IDeliveryModel) => {
            this.deliveryInfo = res;
        });
    }

}