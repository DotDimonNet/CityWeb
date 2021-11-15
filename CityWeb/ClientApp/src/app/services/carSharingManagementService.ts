import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICarSharing, ICreateCarSharingModel, IUpdateCarSharingModel } from "../models/carSharing.model";
import { CarSharingManagmentDataService } from "./carSharingManagementService.data";

@Injectable()
export class CarSharingManagmentService{

    constructor(private dataService: CarSharingManagmentDataService){
    };
    
    createCarSharing(createCarSharingData:ICreateCarSharingModel):Observable<ICarSharing>{
        return this.dataService.createCarSharing(createCarSharingData);
    };

    updateCarSharing(updateCarSharing:IUpdateCarSharingModel, carSharingId:string):Observable<ICarSharing>{
        return this.dataService.updateCarSharing(updateCarSharing, carSharingId);
    };

    deleteCarSharing(carSharingId:string):Observable<boolean>{
        return this.dataService.deleteCarSharing(carSharingId);
    };

    getAllCarSharings():Observable<ICarSharing[]>{
        return this.dataService.getAllCarSharings();
    };

    getCarSharingById(carSharingId:string):Observable<ICarSharing>{
        return this.dataService.getCarSharingById(carSharingId);
    };
}