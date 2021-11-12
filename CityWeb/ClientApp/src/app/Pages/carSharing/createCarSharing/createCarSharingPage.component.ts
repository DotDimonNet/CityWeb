import {Router} from '@angular/router';
import { Component } from '@angular/core';
import { ICarSharing, ICreateCarSharingModel } from 'src/app/models/carSharing.model';
import { CarSharingManagmentService } from 'src/app/services/carSharingManagementService';

@Component({
    selector: 'car-sharing-create',
    templateUrl: './createCarSharingPage.component.html',
    styleUrls: ['./createCarSharingPage.component.css']
})
export class CreateCarSharingPageComponent{

    public carSharingInfo: ICarSharing;

    public createInfo: ICreateCarSharingModel = {
        title: "",
        description: "",
        location: {
            streetName: "",
            houseNumber: "",
            appartmentNumber: ""
        }
    } as ICreateCarSharingModel;

    constructor(
        private service: CarSharingManagmentService, 
        private router: Router
        ){}
    
    public createCarSharing()
    {
        this.service.createCarSharing(this.createInfo)
            .subscribe((res: ICarSharing) => {
                this.carSharingInfo = res;
            });
        this.router.navigateByUrl(`/car-sharing`);
    }
}