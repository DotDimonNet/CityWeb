import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { IDeliveryModel } from "../models/delivery.models";

@Injectable()
export class DeliveryManagementDataService {

    constructor(private client: HttpClient) {}

    createDeliveryCompany(deliveryCompany: any) : Observable<IDeliveryModel> {
        return this.client.post(`/api/delivery`, deliveryCompany)
        .pipe(first(), map((res: any) => {
            return res as  IDeliveryModel;
        }));
    }
}