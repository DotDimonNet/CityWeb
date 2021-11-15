
import { Component, OnInit } from '@angular/core';
import { IHouseBillModel, IUpdateHouseBillModel } from 'src/app/models/houseBill.model';
import { HouseBillManagementService } from 'src/app/services/houseBillManagementService';

@Component({
    selector: 'house-bill-update',
    templateUrl: './updateHouseBillPage.component.html',
    styleUrls: ['./updateHouseBillPage.component.css']
})
export class UpdateHouseBillPageComponent{
    public houseBillInfo: IHouseBillModel = {
        id: "",
        title: "",
        description: "",
        houseHoldAddress: {
            streetName: "",
            appartmentNumber: "",
            houseNumber: ""
        }
    } as IHouseBillModel;

    public updateInfo: IUpdateHouseBillModel = {
        id: "",
        title: "Unknown",
        description: "Unknown",
        houseHoldAddress: {
            streetName: "Unknown",
            houseNumber: "Unknown",
            appartmentNumber: "Unknown"
        }
    } as IUpdateHouseBillModel
    
    public updateHouseBill()
    {
        this.service.updateHouseBill(this.updateInfo)
    };

    constructor(private service: HouseBillManagementService) {}
    
    public update()
    {
        this.service.updateHouseBill(this.updateInfo)
            .subscribe((res: IHouseBillModel) => {
                this.houseBillInfo = res;
            });
    }
}