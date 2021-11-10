import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { ICarSharing, ICreateCarSharingModel } from "../models/carSharing.model";

@Injectable()
export class CarSharingManagmentDataService{

    constructor(private client:HttpClient){}

    createCarSharing(createCarSharing:ICreateCarSharingModel):Observable<ICarSharing>{
        return this.client.post(`/api/car-sharing/manage-car-sharing`, createCarSharing)
        .pipe(first(), map((res: any) => {
            return res as ICarSharing;
        }));
    }

    getAllCarSharings():Observable<ICarSharing[]>{
        return this.client.get(`/api/car-sharing/all`)
        .pipe(first(), map((res: ICarSharing[]) => res));
    }
}