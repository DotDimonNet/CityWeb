import { TypeScriptEmitter } from '@angular/compiler';
import { Component } from '@angular/core';
import { IEntertainmentModel, IAddEntertainment, EntertainmentType } from 'src/app/models/entertainment.model';
import { EntertainmentManagementService } from 'src/app/services/entertainmentManagementService';

@Component({
  selector: 'entertainment/add',
  templateUrl: './addEntertainmentPage.component.html',
  styleUrls: ['./addEntertainmentPage.component.css']
})
export class AddEntertainmentComponent {
  public types = EntertainmentType;
  public entertainmnentInfo: IEntertainmentModel = {
    title: "",
    description: "",
    type: "",
    address:
    {
      houseNumber: "",
      streetName: "",
    }
  } as IEntertainmentModel;

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
