export interface IDeliveryModel {
    title:  string;
    description:  string;
    workSchedule: PeriodModel;
    deliveryPrice: PriceModel;
}

export interface ICreateDeliveryModel {
    title:  string;
    description:  string;
    workSchedule: PeriodModel;
    deliveryPrice: PriceModel;
}

export interface PeriodModel {
    startTime: Date; 
    endTime: Date;
}

export interface PriceModel {
    value: number; 
    tax: number; 
    vat: number;
}

