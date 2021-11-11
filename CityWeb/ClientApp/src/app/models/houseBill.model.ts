export interface IAddress{
    streetName: string,
    houseNumber: string,
    appartmentNumber: string
}

export interface IHouseBillModel {
    title:  string,
    description:  string,
    houseHoldAddress: IAddress
}

export interface ICreateHouseBillModel {
    title:  string,
    description:  string,
    houseHoldAddress: IAddress
   
}

export interface IUpdateHouseBillModel{
    id: string,
    title: string,
    description: string,
    houseHoldAddress: IAddress
}

export interface IDeleteHouseBillModel{
    id: string
}

