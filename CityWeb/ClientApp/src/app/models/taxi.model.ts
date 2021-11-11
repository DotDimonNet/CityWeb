export interface IAddress{
    streetName: string,
    houseNumber: string,
    appartmentNumber: string
}

export interface ITaxi{
    title: string,
    description: string
}

export interface ICreateTaxiModel{
    title: string,
    description: string
}

export interface IUpdateTaxiModel{
    id: string,
    title: string,
    description: string
}

export interface IDeleteTaxiModel{
    id: string
}