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
    id : string,
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