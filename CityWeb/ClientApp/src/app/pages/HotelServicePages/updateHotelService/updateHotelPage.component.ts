
import { Component, OnInit } from '@angular/core';
import { IHotelModel, IUpdateHotelModel } from 'src/app/models/hotel.model';
import { HotelManagementService } from 'src/app/services/hotelManagementService';

@Component({
    selector: 'update',
    templateUrl: './updateHotelPage.component.html',
    styleUrls: ['./updateHotelPage.component.css']
})
export class UpdateHotelPageComponent{

    public updateInfo: IUpdateHotelModel = {
        id: "",
        title: "",
        description: "",
        address: {
            streetName: "",
            houseNumber: "",
        }
    } as IUpdateHotelModel;

    public hotelInfo: IHotelModel = {
        title: "",
        description: "",
        address: {
            streetName: "",
            houseNumber: "",
        }
    } as IHotelModel;

    

    constructor(private service: HotelManagementService){}
    
    public updateHotel()
    {
        this.service.updateHotel(this.updateInfo)
            .subscribe((res: IHotelModel) => {
                this.hotelInfo = res;
            });
    }
}