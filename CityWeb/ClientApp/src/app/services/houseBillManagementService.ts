import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IHouseBillModel, ICreateHouseBillModel } from "src/app/models/houseBill.model";
import { HouseBillManagmentDataService } from "./houseBillManagementService.data";

@Injectable()
export class HouseBillManagmentService {

    constructor(private dataService: HouseBillManagmentDataService){

    }
    
    createHouseBill(createhouseBillData:ICreateHouseBillModel):Observable<IHouseBillModel>{
        return this.dataService.createHouseBill(createhouseBillData);
    };

}