import { TypeScriptEmitter } from '@angular/compiler';
import { Component } from '@angular/core';
import { IEntertainmentModel, IUpdateEntertainmentModel} from 'src/app/models/entertainment.model';
import { EntertainmentManagementService } from 'src/app/services/entertainmentManagementService';

@Component({
  selector: 'entertainment/update',
  templateUrl: './updateEntertainmentPage.component.html',
  styleUrls: ['./updateEntertainmentPage.component.css']
})
export class UpdateEntertainmentComponent {
  public types = [
    {id: 1, name: "Cinema"},
    {id: 2, name: "Fest"},
    {id: 3, name: "Exhibition"},
    {id: 4, name: "Circus"},
    {id: 5, name: "Theatre"},
    {id: 8, name: "Club"},
    {id: 7, name: "Museum"},
  ];
  //public types: EntertainmentType;
  public entertainmnentInfo: IEntertainmentModel;
  public updateInfo: IUpdateEntertainmentModel = {
    title: "",
    description: "",
    type: "",
    address:
        {
            houseNumber: "",
            streetName: "",
        }
    } as IUpdateEntertainmentModel

  constructor(private service: EntertainmentManagementService) { }

  public updateEntertainment() {
    this.service.updateEntertainment(this.updateInfo)
      .subscribe((res: IEntertainmentModel) => {
        this.entertainmnentInfo = res;
      });
  }
}
