
import { Component } from '@angular/core';
import { IHouseBillModel, IDeleteHouseBillModel, IResultModel } from 'src/app/models/houseBill.model';
import { HouseBillManagementService } from 'src/app/services/houseBillManagementService';

@Component({
    selector: 'house-bill-delete',
    templateUrl: './deleteHouseBillPage.component.html',
    styleUrls: ['./deleteHouseBillPage.component.css']
})
export class DeleteHouseBillPageComponent{

    public isSuccess: boolean;

    public deleteHouseBill: IDeleteHouseBillModel = {
        id: "",
        
    };

    public deleteInfo: IResultModel = {
        result: null,
    } as IResultModel;

    constructor(private service: HouseBillManagementService){}
    
    public delete()
    {
        this.service.deleteHouseBill(this.deleteHouseBill)
        .subscribe((res: boolean) => {
            this.isSuccess = res;
        });
    }
}