import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICreateDeliveryModel, IDeliveryModel, IUpdateDeliveryModel, IDelivery, IProductModel, ICreateProduct, IProduct } from "../models/delivery.model";
import { DeliveryManagementDataService } from "./deliveryManagementService.data";

@Injectable()
export class DeliveryManagementService {

    constructor(private dataService: DeliveryManagementDataService) {

    }

    createDeliveryCompany(deliveryModel: ICreateDeliveryModel) : Observable<IDeliveryModel> {
        return this.dataService.createDeliveryCompany(deliveryModel);
    }

    updateDeliveryCompany(updateDelivery: IUpdateDeliveryModel, deliveryId: string) : Observable<IDeliveryModel> {
        return this.dataService.updateDeliveryCompany(updateDelivery, deliveryId);
    }

    deleteDeliveryCompany(deliveryId: string) : Observable<boolean> {
        return this.dataService.deleteDeliveryCompany(deliveryId);
    }

    getAllDeliveryCompany(): Observable<IDelivery[]> {
        return this.dataService.getAllDeliveryCompany()
    };

    showDeliveryCompany(deliveryId:string): Observable<IDeliveryModel> {
        return this.dataService.showDeliveryCompany(deliveryId)
    };

    createProduct(createProduct: ICreateProduct, deliveryId: string): Observable<IProductModel>{
        return this.dataService.createProduct(createProduct, deliveryId)
    }

    getAllProducts(deliveryId: string) : Observable<IProduct[]>{
        return this.dataService.getAllProducts(deliveryId)
    }
}