export interface IDeliveryModel {
    title:  string,
    description:  string,
    deliveryImage: string,
    workSchedule: IPeriodModel,
    deliveryPrice: IPriceModel,
}

export interface ICreateDeliveryModel {
    title:  string,
    description:  string,
    deliveryImage: string,
    workSchedule: IPeriodModel,
    deliveryPrice: IPriceModel,
}

export interface IPeriodModel {
    startTime: Date,
    endTime: Date,
}

export interface IPriceModel {
    value: number, 
    tax: number, 
    vat: number,
}

export interface IUpdateDeliveryModel {
    description : string,
    workSchedule : IPeriodModel,
    deliveryPrice : IPriceModel,
}

export interface IDeleteDeliveryModel {
    id : string,
}

export interface IResultModel {
    result: boolean,
}

export interface IDelivery {
    title: string,
    description: string,
}

export interface ICreateProduct {
    deliveryId: string,
    productName: string,
    productType: string,
    productImage: string,
    productPrice: IPriceModel,
}

export interface IProductModel {
    productName: string,
    productType: string,
    productImage: string,
    productPrice: IPriceModel,
}

export interface IProduct {
    productName: string,
    productType: string,
}