import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { IHotelModel, ICreateHotelModel,IUpdateHotelModel } from "../models/hotel.model";

@Injectable()
export class HotelManagementDataService {

    constructor(private client: HttpClient) {}

    createHotel(hotel: ICreateHotelModel) : Observable<IHotelModel> {
        return this.client.post(`/api/hotel/manage-hotel`, hotel)
        .pipe(first(), map((res: any) => {
            return res as  IHotelModel;
        }));
    }
    updateHotel(updateHotel:IUpdateHotelModel):Observable<IHotelModel>{
        return this.client.put(`/api/hotel/manage-hotel`, updateHotel)
        .pipe(first(), map((res: any) => {
            return res as IHotelModel;
        }));
    }
}