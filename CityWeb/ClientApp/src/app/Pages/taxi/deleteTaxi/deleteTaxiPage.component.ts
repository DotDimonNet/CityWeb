
import { Component } from '@angular/core';
import { ICarSharing, IDeleteCarSharingModel } from 'src/app/models/carSharing.model';
import { IDeleteTaxiModel, ITaxi } from 'src/app/models/taxi.model';
import { CarSharingManagmentService } from 'src/app/services/carSharingManagementService';
import { TaxiManagmentService } from 'src/app/services/taxiManagementService';

@Component({
    selector: 'taxi-delete',
    templateUrl: './deleteTaxiPage.component.html',
    styleUrls: ['./deleteTaxiPage.component.css']
})
export class DeleteTaxiPageComponent{

    public carSharingInfo: ITaxi = {
        title: "",
        description: ""
    } as ITaxi;

    public isDeleteButtonDisabled = false;
    public isSucess: boolean;

    public deleteInfo: IDeleteTaxiModel = {
        id: ""
    } as IDeleteTaxiModel

    constructor(private service: TaxiManagmentService){}
    
    public deleteCarSharing()
    {
        this.service.deleteTaxi(this.deleteInfo)
        .subscribe((res: boolean) => {
            this.isSucess = res;
        });
    }
}