import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute } from '@angular/router';
import { title } from 'process';
import { ICarSharing, IUpdateCarSharingModel } from 'src/app/models/carSharing.model';
import { CarSharingManagmentService } from 'src/app/services/carSharingManagementService';
import { UpdateCarSharingPageComponent } from '../updateCarSharing/updateCarSharingPage.component';

@Component({
    selector: 'car-sharing-company',
    templateUrl: './carSharingCompanyPage.component.html',
    styleUrls: ['./carSharingCompanyPage.component.css']
})
export class CarSharingCompanyPageComponent{

    public carSharingId: string;
    public isSuccess: boolean;
    public isVisible: boolean;
    public carSharingInfo: ICarSharing = {
        title: "",
        description: "",
        location: {
            streetName: "",
            houseNumber: "",
            appartmentNumber: ""
        }
    } as ICarSharing;

    public updateInfo: IUpdateCarSharingModel;

    constructor(
        private service: CarSharingManagmentService, 
        private activatedRoute: ActivatedRoute,
        private router: Router
        ){}

    ngOnInit() {
        this.isVisible = true;
        this.activatedRoute.queryParams.subscribe(params => {
            this.carSharingId = params['id'];
          });
        this.service.getCarSharingById(this.carSharingId)
            .subscribe((res: ICarSharing) => {
                this.carSharingInfo = res;
        });
    }

    public updateCarSharing()
    {
        this.isVisible = !this.isVisible;
        this.updateInfo = {
            title: this.carSharingInfo.title,
            description: this.carSharingInfo.description,
            location: {
                streetName: this.carSharingInfo.location.streetName, 
                houseNumber: this.carSharingInfo.location.houseNumber,
                appartmentNumber: this.carSharingInfo.location.appartmentNumber
            }
        } as IUpdateCarSharingModel
    };

    public ConfirmUpdateCarSharing()
    {
        this.service.updateCarSharing(this.updateInfo, this.carSharingId)
            .subscribe((res: ICarSharing) => {
                this.carSharingInfo = res;
            });
        this.updateInfo = {
            title: "",
            description: "",
            location: {
                streetName: "",
                houseNumber: "",
                appartmentNumber: ""
            }    
        } as IUpdateCarSharingModel
        this.isVisible = true;
    };

    public deleteCarSharing()
    {
        this.service.deleteCarSharing(this.carSharingId)
            .subscribe((res: boolean) => {
                this.isSuccess = res;
            });
        this.router.navigateByUrl(`/car-sharing`);
    };
}