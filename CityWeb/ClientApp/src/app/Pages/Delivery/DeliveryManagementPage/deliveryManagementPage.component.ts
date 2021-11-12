import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { IDeliveryModel } from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'delivery-management',
  templateUrl: './deliveryManagementPage.component.html',
  styleUrls: ['./deliveryManagementPage.component.css']
})

export class DeliveryManagementComponent {
  public deliveryId: string;

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

  constructor(
      private service: DeliveryManagementService, 
      private activatedRoute: ActivatedRoute,
      private router: Router
      ){}

  navigateToUpdate(id: string) {
        this.router.navigateByUrl(`/delivery/update?id=${id}`);
    }
  
  navigateToDelete(id: string) {
      this.router.navigateByUrl(`/delivery/delete?id=${id}`);
    } 

  navigateToProducts(id: string) {
    this.router.navigateByUrl(`/all-products?id=${id}`);
  }   

  ngOnInit() {
      this.activatedRoute.queryParams.subscribe(params => {
          this.deliveryId = params['id'];            
        });
        this.service.showDeliveryCompany(this.deliveryId)
        .subscribe((res: IDeliveryModel) => {
            this.deliveryInfo = res;
      });
  }
  
}
