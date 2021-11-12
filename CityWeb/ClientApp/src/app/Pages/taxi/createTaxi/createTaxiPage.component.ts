import { Component } from '@angular/core';
import { ICreateTaxiModel, ITaxi } from 'src/app/models/taxi.model';
import { TaxiManagmentService } from 'src/app/services/taxiManagementService';

@Component({
    selector: 'taxi-create',
    templateUrl: './createTaxiPage.component.html',
    styleUrls: ['./createTaxiPage.component.css']
})
export class CreateTaxiPageComponent{

    public taxiInfo: ITaxi = {
        title: "",
        description: ""
    } as ITaxi;

    public createInfo: ICreateTaxiModel = {
        title: "",
        description: ""
    } as ICreateTaxiModel

    constructor(private service: TaxiManagmentService){}
    
    public createCarSharing()
    {
        this.service.createTaxi(this.createInfo)
            .subscribe((res: ITaxi) => {
                this.taxiInfo = res;
            });
        this.createInfo = {
            title: "",
            description: "",
            location: {
                streetName: "",
                houseNumber: "",
                appartmentNumber: ""
            }
        } as ICreateTaxiModel
    }
}