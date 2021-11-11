import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICreateDeliveryModel, IDeliveryModel, IUpdateDeliveryModel, IResultModel, IDeleteDeliveryModel, IDelivery } from "../models/delivery.model";
import { DeliveryManagementDataService } from "./deliveryManagementService.data";

@Injectable()
export class DeliveryManagementService {

    constructor(private dataService: DeliveryManagementDataService) {

    }

    createDeliveryCompany(deliveryModel: ICreateDeliveryModel) : Observable<IDeliveryModel> {
        return this.dataService.createDeliveryCompany(deliveryModel);
    }

    updateDeliveryCompany(updateDelivery: IUpdateDeliveryModel) : Observable<IDeliveryModel> {
        return this.dataService.updateDeliveryCompany(updateDelivery);
    }

    deleteDeliveryCompany(deleteDelivery: IDeleteDeliveryModel) : Observable<IResultModel> {
        return this.dataService.deleteDeliveryCompany(deleteDelivery);
    }

    getAllDeliveryCompany(): Observable<IDelivery[]> {
        return this.dataService.getAllDeliveryCompany()
    };

    showDeliveryCompany(): Observable<IDeliveryModel> {
        return this.dataService.showDeliveryCompany()
    };
}