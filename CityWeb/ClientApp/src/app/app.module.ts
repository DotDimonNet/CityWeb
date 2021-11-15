import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import {NgxMaterialTimepickerModule} from 'ngx-material-timepicker';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
//Delivery
import { DeliveryStartPageComponent } from './Pages/Delivery/DeliveryStartPage/deliveryStartPage.component';
import { DeliveryManagementComponent } from './Pages/Delivery/DeliveryManagementPage/deliveryManagementPage.component';
import { CreateDeliveryComponent } from './pages/delivery/createDeliveryPage/createDeliveryPage.component';
import { UpdateDeliveryComponent } from './pages/delivery/updateDeliveryPage/updateDeliveryPage.component';
import { DeleteDeliveryComponent } from './pages/delivery/deleteDeliveryPage/deleteDeliveryPage.component';

import { GetAllDeliveryComponent } from './pages/delivery/getAllDeliveryPage/getAllDeliveryPage.component';
import { CreateProductComponent } from './pages/delivery/createProductPage/createProductPage.component';
import { GetAllProductsComponent } from './pages/delivery/getAllProductsPage/getAllProductsPage.component';
import { CarSharingCompanyPageComponent } from './Pages/carSharing/carSharingCompany/carSharingCompanyPage.component';
import { CreateCarSharingPageComponent } from './Pages/carSharing/createCarSharing/createCarSharingPage.component';
import { HouseBillPageComponent } from './Pages/HouseBill/houseBillPage.component';
import { CreateHouseBillPageComponent } from './Pages/HouseBill/createHouseBill/createHouseBillPage.component';
import { UpdateHouseBillPageComponent } from './Pages/HouseBill/updateHouseBill/updateHouseBillPage.component';
import { DeleteHouseBillPageComponent } from './Pages/HouseBill/deleteHouseBill/deleteHouseBillPage.component';
import { GetAllCarSharingsPageComponent } from './Pages/carSharing/getAllCarSharings/getAllCarSharingsPage.component';
import { CarSharingManagmentService } from './services/carSharingManagementService';
import { CarSharingManagmentDataService } from './services/carSharingManagementService.data';
import { TaxiPageComponent } from './Pages/taxi/taxiPage.component';
import { CreateTaxiPageComponent } from './Pages/taxi/createTaxi/createTaxiPage.component';
import { UpdateTaxiPageComponent } from './Pages/taxi/updateTaxi/updateTaxiPage.component';
import { DeleteTaxiPageComponent } from './Pages/taxi/deleteTaxi/deleteTaxiPage.component';
import { GetAllTaxiPageComponent } from './Pages/taxi/getAllTaxi/getAllTaxiPage.component';
import { TaxiManagmentDataService } from './services/taxiManagementService.data';
import { TaxiManagmentService } from './services/taxiManagementService';
import { DeliveryManagementService } from './services/deliveryManagementService';
import { DeliveryManagementDataService } from './services/deliveryManagementService.data';

import { HouseBillManagementService } from './services/houseBillManagementService';
import { HouseBillManagementDataService } from './services/houseBillManagementService.data'
import { HotelModule } from './pages/HotelServicePages/hotel.module';

//Entertainment
import { EntertainmentManagementService } from './services/entertainmentManagementService';
import { EntertainmentManagementDataService } from './services/entertainmentManagementService.data';
import { AddEntertainmentComponent } from './pages/Entertainment/addEntertainment/addEntertainmentPage.component';
import { EntertainmentPageComponent } from './Pages/Entertainment/entertainmentPage.component';





@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DeliveryStartPageComponent,
    DeliveryManagementComponent,
    CreateDeliveryComponent,
    UpdateDeliveryComponent,
    DeleteDeliveryComponent,
    GetAllDeliveryComponent,
    CreateProductComponent,
    GetAllProductsComponent,
    CreateCarSharingPageComponent,
    CarSharingCompanyPageComponent,
    TaxiPageComponent,
    CreateTaxiPageComponent,
    UpdateTaxiPageComponent,
    DeleteTaxiPageComponent,
    GetAllTaxiPageComponent,
    CreateDeliveryComponent,
    HouseBillPageComponent,
    CreateHouseBillPageComponent,
    UpdateHouseBillPageComponent,
    DeleteHouseBillPageComponent,
    GetAllCarSharingsPageComponent,
    CreateDeliveryComponent,
    EntertainmentPageComponent,
    AddEntertainmentComponent
  ],
  imports: [
    NgxMaterialTimepickerModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HotelModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'car-sharing', component: GetAllCarSharingsPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/create', component: CreateCarSharingPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/company', component: CarSharingCompanyPageComponent, pathMatch: 'full' },
      { path: 'taxi', component: TaxiPageComponent, pathMatch: 'full' },
      { path: 'taxi/create', component: CreateTaxiPageComponent, pathMatch: 'full' },
      { path: 'taxi/update', component: UpdateTaxiPageComponent, pathMatch: 'full' },
      { path: 'taxi/delete', component: DeleteTaxiPageComponent, pathMatch: 'full' },
      { path: 'taxi/get-all', component: GetAllTaxiPageComponent, pathMatch: 'full' },
      { path: 'delivery', component: DeliveryStartPageComponent, pathMatch: 'full' },
      { path: 'delivery-management', component: DeliveryManagementComponent, pathMatch: 'full'},
      { path: 'delivery/create', component: CreateDeliveryComponent, pathMatch: 'full' },
      { path: 'delivery/update', component: UpdateDeliveryComponent, pathMatch: 'full' },
      { path: 'delivery/delete', component: DeleteDeliveryComponent, pathMatch: 'full' },
      { path: 'all-deliveries', component: GetAllDeliveryComponent, pathMatch: 'full' },
      { path: 'product/create', component: CreateProductComponent, pathMatch: 'full' },
      { path: 'all-products', component: GetAllProductsComponent, pathMatch: 'full' },
      { path: 'house-bill', component: HouseBillPageComponent, pathMatch: 'full' },
      { path: 'house-bill/create', component: CreateHouseBillPageComponent, pathMatch: 'full' },
      { path: 'house-bill/update', component: UpdateHouseBillPageComponent, pathMatch: 'full' },
      { path: 'house-bill/delete', component: DeleteHouseBillPageComponent, pathMatch: 'full' },
      { path: 'entertainment', component: EntertainmentPageComponent, pathMatch: 'full' },
      { path: 'entertainment/add', component: AddEntertainmentComponent, pathMatch: 'full' },
    ])
  ],
  providers: [
    CarSharingManagmentService,
    CarSharingManagmentDataService,
    TaxiManagmentService,
    TaxiManagmentDataService,
    DeliveryManagementService,
    DeliveryManagementDataService,
    HouseBillManagementService,
    HouseBillManagementDataService,
    EntertainmentManagementService,
    EntertainmentManagementDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
