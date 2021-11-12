import { Component } from '@angular/core';
import {Router, ActivatedRoute } from '@angular/router';
import { IDelivery } from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
    selector: 'all-deliveries',
    templateUrl: './getAllDeliveryPage.component.html',
    styleUrls: ['./getAllDeliveryPage.component.css']
})
export class GetAllDeliveryComponent{

    public deliveryInfo: IDelivery[];

    constructor(private service: DeliveryManagementService, private router: Router){}

    navigateToDelivery(id: string) {
        this.router.navigateByUrl(`/delivery-management?id=${id}`);
    }
    
    ngOnInit() {
        this.service.getAllDeliveryCompany()
        .subscribe((res: IDelivery[]) => {
            this.deliveryInfo = res;
        });
    }
}
