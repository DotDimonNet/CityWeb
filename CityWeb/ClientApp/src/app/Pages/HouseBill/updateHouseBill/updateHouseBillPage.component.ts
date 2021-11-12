
import { Component, OnInit } from '@angular/core';
import { IHouseBillModel, IUpdateHouseBillModel } from 'src/app/models/houseBill.model';
import { HouseBillManagementService } from 'src/app/services/houseBillManagementService';

@Component({
    selector: 'house-bill-update',
    templateUrl: './updateHouseBillPage.component.html',
    styleUrls: ['./updateHouseBillPage.component.css']
})
export class UpdateHouseBillPageComponent{

    public updateHouseBill: IUpdateHouseBillModel = {
        id: "",
        title: "",
        description: "",
        houseHoldAddress: {
            streetName: "",
            appartmentNumber: "",
            houseNumber: ""
        }
    } as IUpdateHouseBillModel;

    public houseBillInfo: IHouseBillModel = {
        title: "",
        description: "",
        houseHoldAddress: {
            streetName: "",
            houseNumber: "",
            appartmentNumber: ""
        }
    } as IHouseBillModel;

    constructor(private service: HouseBillManagementService) {}
    
    public update()
    {
        this.service.updateHouseBill(this.updateHouseBill)
            .subscribe((res: IHouseBillModel) => {
                this.houseBillInfo = res;
            });
    }
}