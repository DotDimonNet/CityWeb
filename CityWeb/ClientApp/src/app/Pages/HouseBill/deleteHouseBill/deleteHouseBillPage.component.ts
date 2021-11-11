
import { Component } from '@angular/core';
import { IHouseBillModel, IDeleteHouseBillModel } from 'src/app/models/houseBill.model';
import { HouseBillManagementService } from 'src/app/services/houseBillManagementService';

@Component({
    selector: 'house-bill-delete',
    templateUrl: './deleteHouseBillPage.component.html',
    styleUrls: ['./deleteHouseBillPage.component.css']
})
export class DeleteHouseBillPageComponent{

    public HouseBillInfo: IHouseBillModel = {
        title: "",
        description: "",
        houseHoldAddress: {
            streetName: "",
            appartmentNumber: "",
            houseNumber: ""
        }
    } as IHouseBillModel;

    public isDeleteButtonDisabled = false;
    public isSucess: boolean;

    public deleteInfo: IDeleteHouseBillModel = {
        id: ""
    } as IDeleteHouseBillModel

    constructor(private service: HouseBillManagementService){}
    
    public deleteHouseBill()
    {
        this.service.deleteHouseBill(this.deleteInfo)
        .subscribe((res: boolean) => {
            this.isSucess = res;
        });
    }
}