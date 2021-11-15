import * as internal from "assert";

export interface IAddress{
    streetName: string,
    houseNumber: string,
    appartmentNumber: string
}

export interface ICarSharing{
    id: string,
    title: string,
    description: string,
    location: IAddress
}

export interface ICreateCarSharingModel{
    title: string,
    description: string,
    location: IAddress
}

export interface IUpdateCarSharingModel{
    title: string,
    description: string,
    location: IAddress
}

export interface IRentCar{
    nubmer: string,
    mark: string,
    color: string,
    seats: string,
    type: TransportType,
    
}

export enum TransportType{
    Econom,
    Standart,
    Business
}