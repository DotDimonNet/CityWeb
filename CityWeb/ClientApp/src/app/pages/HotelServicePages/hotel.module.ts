import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { HotelManagementDataService } from 'src/app/services/hotelManagementService.data';
import { HotelManagementService } from 'src/app/services/hotelManagementService';
import { HotelPageComponent } from 'src/app/pages/HotelServicePages/hotelPage.component';
import { CreateHotelComponent } from 'src/app/pages/HotelServicePages/createHotelService/createHotelPage.component';
import { UpdateHotelPageComponent } from 'src/app/pages/HotelServicePages/updateHotelService/updateHotelPage.component';


@NgModule({
  declarations: [
    HotelPageComponent,
    CreateHotelComponent,
    UpdateHotelPageComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'hotel', component: HotelPageComponent, pathMatch: 'full' },
      { path: 'hotel/create', component: CreateHotelComponent, pathMatch: 'full' },
      { path: 'hotel/update', component: UpdateHotelPageComponent, pathMatch: 'full' },
    ])
  ],
  providers: [
    HotelManagementService,
    HotelManagementDataService,
  ],
})
export class HotelModule { }
