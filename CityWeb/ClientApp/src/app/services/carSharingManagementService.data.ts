import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { ICarSharing, ICreateCarSharingModel, IDeleteCarSharingModel, IUpdateCarSharingModel } from "../models/carSharing.model";

@Injectable()
export class CarSharingManagmentDataService{

    constructor(private client:HttpClient){}

    createCarSharing(createCarSharing:ICreateCarSharingModel):Observable<ICarSharing>{
        return this.client.post(`/api/car-sharing/create`, createCarSharing)
        .pipe(first(), map((res: any) => {
            return res as ICarSharing;
        }));
    }

    updateCarSharing(updateCarSharing:IUpdateCarSharingModel):Observable<ICarSharing>{
        return this.client.put(`/api/car-sharing/update`, updateCarSharing)
        .pipe(first(), map((res: any) => {
            return res as ICarSharing;
        }));
    }

    deleteCarSharing(carSharingId:string):Observable<boolean>{
        return this.client.delete(`/api/car-sharing/delete/?id=${carSharingId}`)
        .pipe(first(), map((res: any) => {
            return res as boolean;
        }));
    }

    getAllCarSharings():Observable<ICarSharing[]>{
        return this.client.get(`/api/car-sharing/all`)
        .pipe(first(), map((res: ICarSharing[]) => res));
    }

    getCarSharingById(carSharingId: string):Observable<ICarSharing>{
        return this.client.get(`/api/car-sharing/by-id`)
        .pipe(first(), map((res: ICarSharing) => res));
    }
}