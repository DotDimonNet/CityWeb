import { TypeScriptEmitter } from '@angular/compiler';
import { Component } from '@angular/core';
import { IEntertainmentModel, IDeleteEntertainmentModel} from 'src/app/models/entertainment.model';
import { EntertainmentManagementService } from 'src/app/services/entertainmentManagementService';

@Component({
  selector: 'entertainment/delete',
  templateUrl: './deleteEntertainmentPage.component.html',
  styleUrls: ['./deleteEntertainmentPage.component.css']
})
export class UpdateEntertainmentComponent {
  //public types: EntertainmentType;
  public entertainmnentInfo: IEntertainmentModel;
  public deleteInfo: IDeleteEntertainmentModel = {
    title: "",
    } as IDeleteEntertainmentModel

  constructor(private service: EntertainmentManagementService) { }

  public deleteEntertainment() {
    this.service.deleteEntertainment(this.deleteInfo)
      .subscribe((res: IEntertainmentModel) => {
        this.entertainmnentInfo = res;
      });
  }
}
