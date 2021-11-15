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
  isDeleted: Boolean;
}

export interface IAddEntertainment {
  title: string,
  description: string,
  type: string,
  address: IAddress
}
export interface IUpdateEntertainmentModel {
  title: string;
  description: string;
  type: string;
  address: IAddress;
}

export interface IDeleteEntertainmentModel {
  title: string;
}

/*
export enum EntertainmentType 
  {
        Cinema = 1,
        Fest,
        Exhibition,
        Circus,
        Theatre,
        Club,
        Museum,
  }*/