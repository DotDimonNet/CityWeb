import { Component } from '@angular/core';
import { IHouseBillModel, ICreateHouseBillModel } from 'src/app/models/houseBill.model';
import { HouseBillManagementService } from 'src/app/services/houseBillManagementService';

@Component({
    selector: 'house-bill-create',
    templateUrl: './createHouseBillPage.component.html',
    styleUrls: ['./createHouseBillPage.component.css']
})
export class CreateHouseBillPageComponent{

    public houseBillInfo: IHouseBillModel = {
        title: "",
        description: "",
        houseHoldAddress: {
            streetName: "",
            houseNumber: "",
            appartmentNumber: ""
        }
    } as IHouseBillModel;

    public createInfo: ICreateHouseBillModel = {
        title: "",
        description: "",
        houseHoldAddress: {
            streetName: "",
            houseNumber: "",
            appartmentNumber: ""
        }
    } as ICreateHouseBillModel

    constructor(private service: HouseBillManagementService){}
    
    public createHouseBill()
    {
        this.service.createHouseBill(this.createInfo)
            .subscribe((res: IHouseBillModel) => {
                this.houseBillInfo = res;
            });
    }
}