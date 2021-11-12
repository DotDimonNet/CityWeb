import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import {NgxMaterialTimepickerModule} from 'ngx-material-timepicker';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DeliveryManagerPageComponent } from './pages/delivery/deliveryManagerPage/deliveryManagerPage.component';
import { CreateDeliveryComponent } from './pages/delivery/createDeliveryPage/createDeliveryPage.component';
import { UpdateDeliveryComponent } from './pages/delivery/updateDeliveryPage/updateDeliveryPage.component';
import { DeleteDeliveryComponent } from './pages/delivery/deleteDeliveryPage/deleteDeliveryPage.component';
import { CarSharingPageComponent } from './Pages/carSharing/carSharingPage.component';
import { CreateCarSharingPageComponent } from './Pages/carSharing/createCarSharing/createCarSharingPage.component';
import { UpdateCarSharingPageComponent } from './Pages/carSharing/updateCarSharing/updateCarSharingPage.component';
import { DeleteCarSharingPageComponent } from './Pages/carSharing/deleteCarSharing/deleteCarSharingPage.component';
import { HouseBillPageComponent } from './Pages/HouseBill/houseBillPage.component';
import { CreateHouseBillPageComponent } from './Pages/HouseBill/createHouseBill/createHouseBillPage.component';
import { UpdateHouseBillPageComponent } from './Pages/HouseBill/updateHouseBill/updateHouseBillPage.component';
import { DeleteHouseBillPageComponent } from './Pages/HouseBill/deleteHouseBill/deleteHouseBillPage.component';
import { GetAllCarSharingsPageComponent } from './Pages/carSharing/getAllCarSharings/getAllCarSharingsPage.component';
import { CarSharingCompanyPageComponent } from './Pages/carSharing/carSharingCompany/carSharingCompanyPage.component';
import { CarSharingManagmentService } from './services/carSharingManagementService';
import { CarSharingManagmentDataService } from './services/carSharingManagementService.data';
import { TaxiPageComponent } from './Pages/taxi/taxiPage.component';
import { CreateTaxiPageComponent } from './Pages/taxi/createTaxi/createTaxiPage.component';
import { UpdateTaxiPageComponent } from './Pages/taxi/updateTaxi/updateTaxiPage.component';
import { DeleteTaxiPageComponent } from './Pages/taxi/deleteTaxi/deleteTaxiPage.component';
import { GetAllTaxiPageComponent } from './Pages/taxi/getAllTaxi/getAllTaxiPage.component';
import { TaxiManagmentDataService } from './services/taxiManagementService.data';
import { TaxiManagmentService } from './services/taxiManagementService';
import { HouseBillPageComponent } from './Pages/HouseBill/houseBillPage.component';
import { CreateHouseBillPageComponent } from './Pages/HouseBill/createHouseBill/createHouseBillPage.component';
import { DeliveryManagementService } from './services/deliveryManagementService';
import { DeliveryManagementDataService } from './services/deliveryManagementService.data';

import { HouseBillManagementService } from './services/houseBillManagementService';
import { HouseBillManagementDataService } from './services/houseBillManagementService.data'
//Hotel
import { HotelManagementDataService } from './services/hotelManagementService.data';
import { HotelManagementService } from './services/hotelManagementService';
import { HotelPageComponent } from './pages/HotelServicePages/hotelPage.component';
import { CreateHotelComponent } from './pages/HotelServicePages/createHotelService/createHotelPage.component';
import { UpdateHotelPageComponent } from './pages/HotelServicePages/updateHotelService/updateHotelPage.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DeliveryManagerPageComponent,
    CreateDeliveryComponent,
    UpdateDeliveryComponent,
    DeleteDeliveryComponent,
    CarSharingPageComponent,
    CreateCarSharingPageComponent,
    UpdateCarSharingPageComponent,
    DeleteCarSharingPageComponent,
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
    HotelPageComponent,
    CreateHotelComponent,
    UpdateHotelPageComponent,
  ],
  imports: [
    NgxMaterialTimepickerModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'delivery-manager', component: DeliveryManagerPageComponent, pathMatch: 'full' },
      { path: 'create', component: CreateDeliveryComponent, pathMatch: 'full' },
      { path: 'update', component: UpdateDeliveryComponent, pathMatch: 'full' },
      { path: 'delete', component: DeleteDeliveryComponent, pathMatch: 'full' },
      { path: 'car-sharing', component: CarSharingPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/create', component: CreateCarSharingPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/update', component: UpdateCarSharingPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/delete', component: DeleteCarSharingPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/get-all', component: GetAllCarSharingsPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/company', component: CarSharingCompanyPageComponent, pathMatch: 'full' },
      { path: 'taxi', component: TaxiPageComponent, pathMatch: 'full' },
      { path: 'taxi/create', component: CreateTaxiPageComponent, pathMatch: 'full' },
      { path: 'taxi/update', component: UpdateTaxiPageComponent, pathMatch: 'full' },
      { path: 'taxi/delete', component: DeleteTaxiPageComponent, pathMatch: 'full' },
      { path: 'taxi/get-all', component: GetAllTaxiPageComponent, pathMatch: 'full' },
      { path: 'house-bill', component: HouseBillPageComponent, pathMatch: 'full' },
      { path: 'house-bill/create', component: CreateHouseBillPageComponent, pathMatch: 'full' },
      { path: 'house-bill/update', component: UpdateHouseBillPageComponent, pathMatch: 'full' },
      { path: 'house-bill/delete', component: DeleteHouseBillPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/get-all', component: GetAllCarSharingsPageComponent, pathMatch: 'full' },
      { path: 'hotel', component: HotelPageComponent, pathMatch: 'full' },
      { path: 'hotel/create', component: CreateHotelComponent, pathMatch: 'full' },
      { path: 'hotel/update', component: UpdateHotelPageComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
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
    HotelManagementService,
    HotelManagementDataService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
