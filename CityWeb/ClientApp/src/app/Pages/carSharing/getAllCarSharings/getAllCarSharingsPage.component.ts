
import { Component } from '@angular/core';
import { ICarSharing } from 'src/app/models/carSharing.model';
import { CarSharingManagmentService } from 'src/app/services/carSharingManagementService';

@Component({
    selector: 'get-all-car-sharing',
    templateUrl: './getAllCarSharingsPage.component.html',
    styleUrls: ['./getAllCarSharingsPage.component.css']
})
export class GetAllCarSharingsPageComponent{

    public carSharingsInfo: ICarSharing[] = [{
        title: "sss",
        description: "ddd"
    }] as ICarSharing[];

    constructor(private service: CarSharingManagmentService){}
    
    ngOnInit() {
        this.service.getAllCarSharings()
        .subscribe((res: ICarSharing[]) => {
            this.carSharingsInfo = res;
        });
    }
}
