import { Component} from '@angular/core';
import { IDeliveryModel, IDeleteDeliveryModel, IResultModel } from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'delivery/delete',
  templateUrl: './deleteDeliveryPage.component.html',
  styleUrls: ['./deleteDeliveryPage.component.css']
})

export class DeleteDeliveryComponent {
  public deleteDelivery : IDeleteDeliveryModel = {
    id: "",
  };

  public resultInfo: IResultModel = {
    result: null,
   } as IResultModel;

   constructor(private service: DeliveryManagementService) {}

   public delete() {
    this.service.deleteDeliveryCompany(this.deleteDelivery)
    .subscribe((res: IResultModel) => {
        this.resultInfo = res;
    });
  }
}

