export interface IHouseBillModel {
    title:  string,
    description:  string,
    address: IAddress

}

export interface IAddress{
    streetName: string,
    houseNumber: string,
    appartmentNumber: string
}

export interface ICreateHouseBillModel {
    title:  string,
    description:  string,
    address: IAddress
   
}

