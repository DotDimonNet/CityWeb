
import { Component } from '@angular/core';
import { IDeleteTaxiModel, ITaxi } from 'src/app/models/taxi.model';
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