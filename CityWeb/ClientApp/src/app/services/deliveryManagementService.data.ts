import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { IDeliveryModel, ICreateDeliveryModel, IUpdateDeliveryModel, IDeleteDeliveryModel, IResultModel, IDelivery } from "../models/delivery.model";

@Injectable()
export class DeliveryManagementDataService {

    constructor(private client: HttpClient) {}

    createDeliveryCompany(deliveryCompany: ICreateDeliveryModel) : Observable<IDeliveryModel> {
        return this.client.post(`/api/delivery`, deliveryCompany)
        .pipe(first(), map((res: any) => {
            return res as  IDeliveryModel;
        }));
    }

    updateDeliveryCompany(updateDelivery: IUpdateDeliveryModel) : Observable<IDeliveryModel> {
        return this.client.put('/api/delivery', updateDelivery)
        .pipe(first(), map((res: any) => {
            return res as IDeliveryModel;
        }));
    }

    deleteDeliveryCompany(deleteDelivery: IDeleteDeliveryModel) : Observable<IResultModel> {
        return this.client.delete('/api/delivery')
        .pipe(first(), map((res: any) => {
            return res as IResultModel;
        }));
    }

    getAllDeliveryCompany():Observable<IDelivery[]>{
        return this.client.get(`api/delivery/deliveries`)
        .pipe(first(), map((res: IDelivery[]) => res));
    }

    showDeliveryCompany():Observable<IDeliveryModel>{
        return this.client.get(`api/delivery/by-id`)
        .pipe(first(), map((res: IDeliveryModel) => res));
    }
}