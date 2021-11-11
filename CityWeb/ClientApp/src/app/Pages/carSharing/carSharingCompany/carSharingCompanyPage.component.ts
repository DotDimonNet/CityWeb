import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute } from '@angular/router';
import { ICarSharing } from 'src/app/models/carSharing.model';
import { CarSharingManagmentService } from 'src/app/services/carSharingManagementService';

@Component({
    selector: 'car-sharing-company',
    templateUrl: './carSharingCompanyPage.component.html',
    styleUrls: ['./carSharingCompanyPage.component.css']
})
export class CarSharingCompanyPageComponent{

    public carSharingId: string;
    public carSharingInfo: ICarSharing;
    public isSuccess: boolean;

    constructor(private service: CarSharingManagmentService, private activatedRoute: ActivatedRoute){}

    ngOnInit() {
        this.activatedRoute.queryParams.subscribe(params => {
            this.carSharingId = params['id'];            
          });
        this.service.getCarSharingById(this.carSharingId)
            .subscribe((res: ICarSharing) => {
                this.carSharingInfo = res;
        });
    }

    public deleteCarSharing()
    {
        this.service.deleteCarSharing(this.carSharingId)
            .subscribe((res: boolean) => {
                this.isSuccess = res;
            });
    }
}