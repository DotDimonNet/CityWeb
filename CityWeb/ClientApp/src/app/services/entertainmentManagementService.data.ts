import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { first, map, take } from "rxjs/operators";
import { IEntertainmentModel, IAddEntertainment, IUpdateEntertainmentModel } from "../models/entertainment.model";

@Injectable()
export class EntertainmentManagementDataService {

  constructor(private client: HttpClient) { }

  addEntertainment(entertainment: IAddEntertainment): Observable<IEntertainmentModel> {
    return this.client.put(`/api/entertainment/add`, entertainment)
      .pipe(first(), map((res: any) => {
        return res as IEntertainmentModel;
      }));  
  }
  updateEntertainment(entertainment: IUpdateEntertainmentModel): Observable<IEntertainmentModel> {
    return this.client.post(`/api/entertainment/update`, entertainment)
      .pipe(first(), map((res: any) => {
        return res as IEntertainmentModel;
      }));
  }
  

}
