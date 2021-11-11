import { Component } from '@angular/core';
import { IDelivery } from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
    selector: 'all-deliveries',
    templateUrl: './getAllDeliveryPage.component.html',
    styleUrls: ['./getAllDeliveryPage.component.css']
})
export class GetAllDeliveryComponent{

    public deliveryInfo: IDelivery[] = [{
        title: "",
        description: ""
    }] as IDelivery[];

    constructor(private service: DeliveryManagementService){}
    
    ngOnInit() {
        this.service.getAllDeliveryCompany()
        .subscribe((res: IDelivery[]) => {
            this.deliveryInfo = res;
        });
    }
}
