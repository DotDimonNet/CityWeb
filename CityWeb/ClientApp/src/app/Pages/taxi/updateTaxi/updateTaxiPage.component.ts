import { Component } from '@angular/core';
import { ITaxi, IUpdateTaxiModel } from 'src/app/models/taxi.model';
import { TaxiManagmentService } from 'src/app/services/taxiManagementService';

@Component({
    selector: 'taxi-update',
    templateUrl: './updateTaxiPage.component.html',
    styleUrls: ['./updateTaxiPage.component.css']
})
export class UpdateTaxiPageComponent{
    public taxiInfo: ITaxi = {
        title: "",
        description: ""
    } as ITaxi;

    public updateInfo: IUpdateTaxiModel = {
        id: "",
        title: "",
        description: ""
    } as IUpdateTaxiModel

    constructor(private service: TaxiManagmentService){}
    
    public updateTaxi()
    {
        this.service.updateTaxi(this.updateInfo)
            .subscribe((res: ITaxi) => {
                this.taxiInfo = res;
            });
    }
}