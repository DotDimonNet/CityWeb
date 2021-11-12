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