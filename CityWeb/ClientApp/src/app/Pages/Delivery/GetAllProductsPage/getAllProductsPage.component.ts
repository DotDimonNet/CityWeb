import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
    selector: 'all-products',
    templateUrl: './getAllProductsPage.component.html',
    styleUrls: ['./getAllProductsPage.component.css']
})
export class GetAllProductsComponent implements OnInit{
    public deliveryId: string;

    public productInfo: IProduct[];

    constructor(private service: DeliveryManagementService, private router: Router, private activatedRoute: ActivatedRoute){}

    navigateToCreateProduct(id: string) {
        this.router.navigateByUrl(`product/create?id=${id}`);
    }

    navigateToDelivery(id: string) {
        this.router.navigateByUrl(`/product-management?id=${id}`);
    }
    
    ngOnInit() {
        this.activatedRoute.queryParams.subscribe(params => {
            this.deliveryId = params['id'];      
            this.service.getAllProducts(this.deliveryId)
            .subscribe((res: IProduct[]) => {
                this.productInfo = res;
            });      
          });
          
    }
}
