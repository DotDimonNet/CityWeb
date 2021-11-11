import { Component } from '@angular/core';
import { ITaxi } from 'src/app/models/taxi.model';
import { TaxiManagmentService } from 'src/app/services/taxiManagementService';

@Component({
    selector: 'all-taxi',
    templateUrl: './getAllTaxiPage.component.html',
    styleUrls: ['./getAllTaxiPage.component.css']
})
export class GetAllTaxiPageComponent{

    public taxiInfo: ITaxi[] = [{
        title: "sss",
        description: "ddd"
    }] as ITaxi[];

    constructor(private service: TaxiManagmentService){}
    
    ngOnInit() {
        this.service.getAllTaxi()
        .subscribe((res: ITaxi[]) => {
            this.taxiInfo = res;
        });
    }
}
