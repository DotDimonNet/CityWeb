import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { IDeliveryModel, ICreateDeliveryModel, IUpdateDeliveryModel, IProductModel, IDelivery, ICreateProduct, IProduct } from "../models/delivery.model";

@Injectable()
export class DeliveryManagementDataService {

    constructor(private client: HttpClient) {}

    createDeliveryCompany(deliveryCompany: ICreateDeliveryModel) : Observable<IDeliveryModel> {
        return this.client.post(`/api/delivery`, deliveryCompany)
        .pipe(first(), map((res: any) => {
            return res as  IDeliveryModel;
        }));
    }

    updateDeliveryCompany(updateDelivery: IUpdateDeliveryModel, deliveryId: string) : Observable<IDeliveryModel> {
        return this.client.put(`/api/delivery?id=${deliveryId}`, updateDelivery)
        .pipe(first(), map((res: any) => {
            return res as IDeliveryModel;
        }));
    }

    deleteDeliveryCompany(deliveryId: string) : Observable<boolean> {
        return this.client.delete(`/api/delivery?id=${deliveryId}`)
        .pipe(first(), map((res: any) => {
            return res as boolean;
        }));
    }

    getAllDeliveryCompany():Observable<IDelivery[]>{
        return this.client.get(`/api/delivery/deliveries`)
        .pipe(first(), map((res: IDelivery[]) => res));
    }

    showDeliveryCompany(deliveryId: string):Observable<IDeliveryModel>{
        return this.client.get(`/api/delivery/by-id?id=${deliveryId}`)
        .pipe(first(), map((res: IDeliveryModel) => res));
    }

    createProduct(createProduct: ICreateProduct, deliveryId: string):Observable<IProductModel>{
        return this.client.post(`/api/delivery/product/?id=${deliveryId}`,createProduct)
        .pipe(first(),map((res: IProductModel) => res));
    }

    getAllProducts(deliveryId: string):Observable<IProduct[]>{
        return this.client.get(`/api/delivery/products?id=${deliveryId}`)
        .pipe(first(), map((res: IProduct[]) => res));
    }
}