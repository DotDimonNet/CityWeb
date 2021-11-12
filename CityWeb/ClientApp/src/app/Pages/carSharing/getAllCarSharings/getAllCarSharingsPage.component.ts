import {Router} from '@angular/router';
import { Component } from '@angular/core';
import { ICarSharing } from 'src/app/models/carSharing.model';
import { CarSharingManagmentService } from 'src/app/services/carSharingManagementService';

@Component({
    selector: 'car-sharing',
    templateUrl: './getAllCarSharingsPage.component.html',
    styleUrls: ['./getAllCarSharingsPage.component.css']
})
export class GetAllCarSharingsPageComponent{

    public carSharingsInfo: ICarSharing[];

    constructor(private service: CarSharingManagmentService, private router: Router){}

    navigateToCarSharing(id: string) {
        this.router.navigateByUrl(`/car-sharing/company?id=${id}`);
    }

    ngOnInit() {
        this.service.getAllCarSharings()
        .subscribe((res: ICarSharing[]) => {
            this.carSharingsInfo = res;
        });
    }
}
