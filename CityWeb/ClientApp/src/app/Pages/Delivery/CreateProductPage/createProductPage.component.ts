import { Component, OnInit } from '@angular/core';
import {Router, ActivatedRoute } from '@angular/router';
import { ICreateProduct, IProductModel} from 'src/app/models/delivery.model';
import { DeliveryManagementService } from 'src/app/services/deliveryManagementService';

@Component({
  selector: 'product/create',
  templateUrl: './createProductPage.component.html',
  styleUrls: ['./createProductPage.component.css']
})

export class CreateProductComponent implements OnInit{

    public deliveryId: string;

    public picker: any;
    public createProduct: ICreateProduct = {
        productName: "",
        productType: "",
        productImage: "",
        productPrice: {
            value: 0, 
            tax: 0, 
            vat: 0,
        },
    } as ICreateProduct;

    public productInfo: IProductModel = {
        productName: "",
        productType: "",
        productImage: "",
        productPrice: {
            value: 0, 
            tax: 0, 
            vat: 0,
        },
    } as IProductModel;

    constructor(
        private service: DeliveryManagementService, 
        private activatedRoute: ActivatedRoute
    ){}

    public create() {
        this.service.createProduct(this.createProduct, this.deliveryId)
        .subscribe((res: IProductModel) => {
            this.productInfo = res;
        });
    }
    
    ngOnInit() {
        this.activatedRoute.queryParams.subscribe(params => {
            this.deliveryId = params['id'];            
            });
        }
}