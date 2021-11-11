import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IHouseBillModel, ICreateHouseBillModel, IUpdateHouseBillModel, IDeleteHouseBillModel} from "src/app/models/houseBill.model";
import { HouseBillManagementDataService } from "./houseBillManagementService.data";

@Injectable()
export class HouseBillManagementService {

    constructor(private dataService: HouseBillManagementDataService){

    }
    
    createHouseBill(createhouseBillData:ICreateHouseBillModel):Observable<IHouseBillModel>{
        return this.dataService.createHouseBill(createhouseBillData);
    };

    updateHouseBill(updateHouseBill:IUpdateHouseBillModel):Observable<IHouseBillModel>{
        return this.dataService.updateHouseBill(updateHouseBill);
    }

    deleteHouseBill(deleteHouseBill:IDeleteHouseBillModel):Observable<boolean>{
        return this.dataService.deleteHouseBill(deleteHouseBill);
    }

    

}