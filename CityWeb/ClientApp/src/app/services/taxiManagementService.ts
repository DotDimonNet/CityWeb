import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICreateTaxiModel, IDeleteTaxiModel, ITaxi, IUpdateTaxiModel } from "../models/taxi.model";
import { TaxiManagmentDataService } from "./taxiManagementService.data";

@Injectable()
export class TaxiManagmentService{

    constructor(private dataService: TaxiManagmentDataService){
    }
    
    createTaxi(createTaxi:ICreateTaxiModel):Observable<ITaxi>{
        return this.dataService.createTaxi(createTaxi);
    };

    updateTaxi(updateTaxi:IUpdateTaxiModel):Observable<ITaxi>{
        return this.dataService.updateTaxi(updateTaxi);
    }

    deleteTaxi(deleteTaxi:IDeleteTaxiModel):Observable<boolean>{
        return this.dataService.deleteTaxi(deleteTaxi);
    };

    getAllTaxi():Observable<ITaxi[]>{
        return this.dataService.getAllTaxi();
    };
}