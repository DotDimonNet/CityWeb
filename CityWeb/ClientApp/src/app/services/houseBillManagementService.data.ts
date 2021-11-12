
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { IHouseBillModel, ICreateHouseBillModel, IUpdateHouseBillModel, IDeleteHouseBillModel } from "src/app/models/houseBill.model";
import { IResultModel } from "../models/delivery.model";


@Injectable()
export class HouseBillManagementDataService{

    constructor(private client:HttpClient){}

    createHouseBill(createHouseBill:ICreateHouseBillModel):Observable<IHouseBillModel>{
        return this.client.post(`/api/house-bill/create`, createHouseBill)

        .pipe(first(), map((res: any) => {
            return res as IHouseBillModel;
        })); 
    }

    updateHouseBill(updateHouseBill:IUpdateHouseBillModel):Observable<IHouseBillModel>{
        return this.client.put('/api/house-bill/update', updateHouseBill)
        .pipe(first(), map((res: any) => {
            return res as IHouseBillModel;
        })); 
    }

    deleteHouseBill(deleteHouseBill:IDeleteHouseBillModel):Observable<boolean>{
        return this.client.delete(`/api/house-bill/delete/?request=${deleteHouseBill}`)
        .pipe(first(),map((res: any) => {
            return res as boolean;
        }));
    }
}