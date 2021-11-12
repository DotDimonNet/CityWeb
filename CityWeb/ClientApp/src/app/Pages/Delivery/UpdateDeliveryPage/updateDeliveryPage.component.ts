import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import {Router, ActivatedRoute } from '@angular/router';
import { IDeliveryModel,  IUpdateDeliveryModel} from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'delivery/update',
  templateUrl: './updateDeliveryPage.component.html',
  styleUrls: ['./updateDeliveryPage.component.css']
})

export class UpdateDeliveryComponent {
  public deliveryId: string;
  public isSuccess: boolean;

  constructor(
      private service: DeliveryManagementService, 
      private activatedRoute: ActivatedRoute,
      private router: Router
      ){}

    // public updateDelivery: IUpdateDeliveryModel = {
    //   description: "",
    //   deliveryImage: "",
    //   workSchedule:  {
    //       startTime: new Date(),
    //       endTime: new Date(),
    //   },
    //   deliveryPrice: {
    //       value: 0, 
    //       tax: 0, 
    //       vat: 0,
    //   },
    // } as IUpdateDeliveryModel;

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
    
    ngOnInit() {
      this.activatedRoute.queryParams.subscribe(params => {
          this.deliveryId = params['id'];            
        });
        this.service.showDeliveryCompany(this.deliveryId)
        .subscribe((res: IDeliveryModel) => {
            this.deliveryInfo = res;
      });
      }

  public update() {
        this.service.updateDeliveryCompany(this.deliveryInfo, this.deliveryId)
        .subscribe((res: IDeliveryModel) => {
            this.deliveryInfo = res;
        });
    }
}