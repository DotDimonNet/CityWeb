import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { ICreateTaxiModel, IDeleteTaxiModel, ITaxi, IUpdateTaxiModel } from "../models/taxi.model";

@Injectable()
export class TaxiManagmentDataService{

    constructor(private client:HttpClient){}

    createTaxi(createTaxi:ICreateTaxiModel):Observable<ITaxi>{
        return this.client.post(`/api/taxi/create`, createTaxi)
        .pipe(first(), map((res: any) => {
            return res as ITaxi;
        }));
    }

    updateTaxi(updateTaxi:IUpdateTaxiModel):Observable<ITaxi>{
        return this.client.put(`/api/taxi/update`, updateTaxi)
        .pipe(first(), map((res: any) => {
            return res as ITaxi;
        }));
    }

    deleteTaxi(deleteTaxi:IDeleteTaxiModel):Observable<boolean>{
        return this.client.delete(`/api/taxi/delete/?request=${deleteTaxi}`)
        .pipe(first(), map((res: any) => {
            return res as boolean;
        }));
    }

    getAllTaxi():Observable<ITaxi[]>{
        return this.client.get(`/api/taxi/all`)
        .pipe(first(), map((res: ITaxi[]) => res));
    }
}