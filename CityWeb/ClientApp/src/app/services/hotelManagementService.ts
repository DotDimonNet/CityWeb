import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICreateHotelModel, IHotelModel } from "../models/hotel.model";
import { HotelManagementDataService } from "./hotelManagementService.data";

@Injectable()
export class HotelManagementService {

    constructor(private dataService: HotelManagementDataService) {

    }

    createHotel(hotelModel: ICreateHotelModel) : Observable<IHotelModel> {
        return this.dataService.createHotel(hotelModel);
    }
}