import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICarSharing, ICreateCarSharingModel } from "../models/carSharing.model";
import { CarSharingManagmentDataService } from "./carSharingManagementService.data";

@Injectable()
export class CarSharingManagmentService{

    constructor(private dataService: CarSharingManagmentDataService){

    }
    
    createCarSharing(createCarSharingData:ICreateCarSharingModel):Observable<ICarSharing>{
        return this.dataService.createCarSharing(createCarSharingData);
    };

    getAllCarSharings():Observable<ICarSharing>{
        return this.dataService.getAllCarSharings();
    };
}