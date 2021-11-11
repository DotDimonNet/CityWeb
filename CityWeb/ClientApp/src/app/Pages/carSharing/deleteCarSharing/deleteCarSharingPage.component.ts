
import { Component } from '@angular/core';
import { ICarSharing, IDeleteCarSharingModel } from 'src/app/models/carSharing.model';
import { CarSharingManagmentService } from 'src/app/services/carSharingManagementService';

@Component({
    selector: 'car-sharing-delete',
    templateUrl: './deleteCarSharingPage.component.html',
    styleUrls: ['./deleteCarSharingPage.component.css']
})
export class DeleteCarSharingPageComponent{

    public carSharingInfo: ICarSharing = {
        title: "",
        description: "",
        location: {
            streetName: "",
            appartmentNumber: "",
            houseNumber: ""
        }
    } as ICarSharing;

    public isDeleteButtonDisabled = false;
    public isSucess: boolean;

    public deleteInfo: IDeleteCarSharingModel = {
        id: ""
    } as IDeleteCarSharingModel

    constructor(private service: CarSharingManagmentService){}
}