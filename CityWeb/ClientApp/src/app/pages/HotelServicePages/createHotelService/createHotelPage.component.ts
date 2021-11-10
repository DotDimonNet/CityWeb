import { Component } from '@angular/core';
import { IHotelModel, ICreateHotelModel } from 'src/app/models/hotel.model';
import { HotelManagementService } from 'src/app/services/hotelManagementService';

@Component({
    selector: 'create',
    templateUrl: './createHotelPage.component.html',
    styleUrls: ['./createHotelPage.component.css']
})
export class CreateHotelComponent{

    public hotelInfo: IHotelModel = {
        title: "",
        description: "",
        image: "",
        address:
        {
            houseNumber: "",
            streetName: "",
        }
    } as IHotelModel;

    public createInfo: ICreateHotelModel = {
        title: "",
        description: "",
        image: "",
        address:
        {
            houseNumber: "",
            streetName: "",
        }
    } as ICreateHotelModel

    constructor(private service: HotelManagementService){}
    
    public createHotel()
    {
        this.service.createHotel(this.createInfo)
            .subscribe((res: IHotelModel) => {
                this.hotelInfo = res;
            });
    }
}