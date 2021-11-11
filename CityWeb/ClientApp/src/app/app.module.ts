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
import { CarSharingPageComponent } from './Pages/carSharing/carSharingPage.component';
import { CreateCarSharingPageComponent } from './Pages/carSharing/createCarSharing/createCarSharingPage.component';
import { UpdateCarSharingPageComponent } from './Pages/carSharing/updateCarSharing/updateCarSharingPage.component';
import { DeleteCarSharingPageComponent } from './Pages/carSharing/deleteCarSharing/deleteCarSharingPage.component';
import { HouseBillPageComponent } from './Pages/HouseBill/houseBillPage.component';
import { CreateHouseBillPageComponent } from './Pages/HouseBill/createHouseBill/createHouseBillPage.component';
import { GetAllCarSharingsPageComponent } from './Pages/carSharing/getAllCarSharings/getAllCarSharingsPage.component';
import { CarSharingManagmentService } from './services/carSharingManagementService';
import { CarSharingManagmentDataService } from './services/carSharingManagementService.data';
import { DeliveryManagementService } from './services/deliveryManagementService';
import { DeliveryManagementDataService } from './services/deliveryManagementService.data';

import { HouseBillManagmentService } from './services/houseBillManagementService';
import { HouseBillManagmentDataService } from './services/houseBillManagementService.data'
//Hotel
import { HotelManagementDataService } from './services/hotelManagementService.data';
import { HotelManagementService } from './services/hotelManagementService';
import { HotelPageComponent } from './pages/HotelServicePages/hotelPage.component';
import { CreateHotelComponent } from './pages/HotelServicePages/createHotelService/createHotelPage.component';


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
    CarSharingPageComponent,
    CreateCarSharingPageComponent,
    UpdateCarSharingPageComponent,
    DeleteCarSharingPageComponent,
    CreateDeliveryComponent,
    HouseBillPageComponent,
    CreateHouseBillPageComponent,
    GetAllCarSharingsPageComponent,
    CreateDeliveryComponent,
    HotelPageComponent,
    CreateHotelComponent,
  ],
  imports: [
    NgxMaterialTimepickerModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'delivery', component: DeliveryStartPageComponent, pathMatch: 'full' },
      { path: 'all-deliveries/delivery-management', component: DeliveryManagementComponent, pathMatch: 'full'},
      { path: 'delivery/create', component: CreateDeliveryComponent, pathMatch: 'full' },
      { path: 'delivery/update', component: UpdateDeliveryComponent, pathMatch: 'full' },
      { path: 'delivery/delete', component: DeleteDeliveryComponent, pathMatch: 'full' },
      { path: 'all-deliveries', component: GetAllDeliveryComponent, pathMatch: 'full' },
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'car-sharing', component: CarSharingPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/create', component: CreateCarSharingPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/update', component: UpdateCarSharingPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/delete', component: DeleteCarSharingPageComponent, pathMatch: 'full' },
      { path: 'house-bill', component: HouseBillPageComponent, pathMatch: 'full' },
      { path: 'house-bill/create', component: CreateHouseBillPageComponent, pathMatch: 'full' },
      { path: 'car-sharing/get-all', component: GetAllCarSharingsPageComponent, pathMatch: 'full' },
      { path: 'hotel', component: HotelPageComponent, pathMatch: 'full' },
      { path: 'hotel/create', component: CreateHotelComponent, pathMatch: 'full' },
    ])
  ],
  providers: [
    CarSharingManagmentService,
    CarSharingManagmentDataService,
    DeliveryManagementService,
    DeliveryManagementDataService,
    HouseBillManagmentService,
    HouseBillManagmentDataService,
    HotelManagementService,
    HotelManagementDataService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
