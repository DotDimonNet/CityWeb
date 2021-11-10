import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICreateDeliveryModel, IDeliveryModel } from "../models/delivery.model";
import { DeliveryManagementDataService } from "./deliveryManagementService.data";

@Injectable()
export class DeliveryManagementService {

    constructor(private dataService: DeliveryManagementDataService) {

    }

    createDeliveryCompany(deliveryModel: ICreateDeliveryModel) : Observable<IDeliveryModel> {
        return this.dataService.createDeliveryCompany(deliveryModel);
    }
}