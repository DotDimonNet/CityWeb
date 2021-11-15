import { TypeScriptEmitter } from '@angular/compiler';
import { Component } from '@angular/core';
import { IEntertainmentModel, IAddEntertainment} from 'src/app/models/entertainment.model';
import { EntertainmentManagementService } from 'src/app/services/entertainmentManagementService';

@Component({
  selector: 'entertainment/add',
  templateUrl: './addEntertainmentPage.component.html',
  styleUrls: ['./addEntertainmentPage.component.css']
})
export class AddEntertainmentComponent {
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
  public createInfo: IAddEntertainment = {
    title: "",
    description: "",
    type: "",
    address:
        {
            houseNumber: "",
            streetName: "",
        }
    } as IAddEntertainment

  constructor(private service: EntertainmentManagementService) { }

  public addEntertainment() {
    this.service.addEntertainment(this.createInfo)
      .subscribe((res: IEntertainmentModel) => {
        this.entertainmnentInfo = res;
      });
  }
}
