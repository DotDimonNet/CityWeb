export interface IAddress {
  streetName: string,
  houseNumber: string,
  appartmentNumber: string
}

export interface IEntertainmentModel {
  title: string;
  description: string;
  type: string;
  address: IAddress;
}

export interface IAddEntertainment {
  title: string,
  description: string,
  type: string,
  address: IAddress
}

export enum EntertainmentType{
  cinema,
  fest,
  exhibition,
  circus,
  theatre,
  club ,
  museum
}
