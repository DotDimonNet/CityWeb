import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IAddEntertainment, IEntertainmentModel,IUpdateEntertainmentModel} from "../models/entertainment.model";
import { EntertainmentManagementDataService } from "./entertainmentManagementService.data";

@Injectable()
export class EntertainmentManagementService {

  constructor(private dataService: EntertainmentManagementDataService) {

    }

    addEntertainment(entertainmentModel: IAddEntertainment) : Observable<IEntertainmentModel> {
      return this.dataService.addEntertainment(entertainmentModel);
    }
    updateEntertainment(entertainmentModel: IUpdateEntertainmentModel): Observable<IEntertainmentModel> {
      return this.dataService.updateEntertainment(entertainmentModel);
    }
}
