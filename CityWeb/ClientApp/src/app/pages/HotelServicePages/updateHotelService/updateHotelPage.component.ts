
import { Component, OnInit } from '@angular/core';
import { IHotelModel, ICreateHotelModel, IUpdateHotelModel } from 'src/app/models/hotel.model';
import { HotelManagementService } from 'src/app/services/hotelManagementService';

@Component({
    selector: 'update',
    templateUrl: './updateHotelPage.component.html',
    styleUrls: ['./updateHotelPage.component.css']
})
export class UpdateHotelPageComponent{

    public hotelInfo: IHotelModel = {
        title: "",
        description: "",
        address: {
            streetName: "",
            houseNumber: "",
        }
    } as IHotelModel;

    public updateInfo: IUpdateHotelModel = {
        id: "",
        title: "Unknown",
        description: "Unknown",
        address: {
            streetName: "Unknown",
            houseNumber: "Unknown",
        }
    } as IUpdateHotelModel

    constructor(private service: HotelManagementService){}
    
    public updateHotel()
    {
        this.service.updateHotel(this.updateInfo)
            .subscribe((res: IHotelModel) => {
                this.hotelInfo = res;
            });
    }
}