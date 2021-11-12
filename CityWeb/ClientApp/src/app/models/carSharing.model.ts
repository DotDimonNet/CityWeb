export interface IAddress{
    streetName: string,
    houseNumber: string,
    appartmentNumber: string
}

export interface ICarSharing{
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
    id: string,
    title: string,
    description: string,
    location: IAddress
}

export interface IDeleteCarSharingModel{
    id: string
}