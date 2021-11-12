
import { Component } from '@angular/core';
import { ICarSharing, ICreateCarSharingModel } from 'src/app/models/carSharing.model';
import { CarSharingManagmentService } from 'src/app/services/carSharingManagementService';

@Component({
    selector: 'car-sharing-create',
    templateUrl: './createCarSharingPage.component.html',
    styleUrls: ['./createCarSharingPage.component.css']
})
export class CreateCarSharingPageComponent{

    public carSharingInfo: ICarSharing = {
        title: "",
        description: "",
        location: {
            streetName: "",
            appartmentNumber: "",
            houseNumber: ""
        }
    } as ICarSharing;

    public createInfo: ICreateCarSharingModel

    constructor(private service: CarSharingManagmentService){}
    
    public createCarSharing()
    {
        this.service.createCarSharing(this.createInfo)
            .subscribe((res: ICarSharing) => {
                this.carSharingInfo = res;
            });
        this.createInfo = {
            title: "",
            description: "",
            location: {
                streetName: "",
                houseNumber: "",
                appartmentNumber: ""
            }
        } as ICreateCarSharingModel
    }
}