
import { Component, OnInit } from '@angular/core';
import { ICarSharing, ICreateCarSharingModel, IUpdateCarSharingModel } from 'src/app/models/carSharing.model';
import { CarSharingManagmentService } from 'src/app/services/carSharingManagementService';

@Component({
    selector: 'car-sharing-update',
    templateUrl: './updateCarSharingPage.component.html',
    styleUrls: ['./updateCarSharingPage.component.css']
})
export class UpdateCarSharingPageComponent{

    public carSharingInfo: ICarSharing = {
        title: "",
        description: "",
        location: {
            streetName: "",
            appartmentNumber: "",
            houseNumber: ""
        }
    } as ICarSharing;

    public updateInfo: IUpdateCarSharingModel = {
        id: "",
        title: "",
        description: "",
        location: {
            streetName: "",
            houseNumber: "",
            appartmentNumber: ""
        }
    } as IUpdateCarSharingModel

    constructor(private service: CarSharingManagmentService){}
    
    public updateCarSharing()
    {
        this.service.updateCarSharing(this.updateInfo)
            .subscribe((res: ICarSharing) => {
                this.carSharingInfo = res;
            });
    }
}