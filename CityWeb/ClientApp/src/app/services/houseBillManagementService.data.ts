
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { IHouseBillModel, ICreateHouseBillModel } from "src/app/models/houseBill.model";


@Injectable()
export class HouseBillManagmentDataService{

    constructor(private client:HttpClient){}

    createHouseBill(createHouseBill:ICreateHouseBillModel):Observable<IHouseBillModel>{
        return this.client.post(`/api/house-bill/housebill-create`, createHouseBill)
        .pipe(first(), map((res: any) => {
            return res as IHouseBillModel;
        }));
    }
}