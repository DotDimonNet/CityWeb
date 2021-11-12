import { Component} from '@angular/core';
import {Router, ActivatedRoute } from '@angular/router';
import { IDeliveryModel, IResultModel } from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'delivery/delete',
  templateUrl: './deleteDeliveryPage.component.html',
  styleUrls: ['./deleteDeliveryPage.component.css']
})

export class DeleteDeliveryComponent {
  public deliveryId: string;
  public deliveryInfo: IDeliveryModel;
  public result: boolean;
  

   constructor(
     private service: DeliveryManagementService,
     private activatedRoute: ActivatedRoute,
     private router: Router
    ) {}

   ngOnInit() {
    this.activatedRoute.queryParams.subscribe(params => {
        this.deliveryId = params['id'];            
      });
    }

   public delete() {
    this.service.deleteDeliveryCompany(this.deliveryId)
    .subscribe((res: boolean) => {
        this.result = res;
    });
  }
}

