export interface IHotelModel {
    title:  string;
    description:  string;
    image: string;
    address: IHotelAddressModel;
}

export interface ICreateHotelModel {
    title:  string;
    description:  string;
    image: string;
    address: IHotelAddressModel;
}

export interface IHotelAddressModel {
    streetName: string;
    houseNumber: string;
}



