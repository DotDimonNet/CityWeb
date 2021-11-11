import { Component } from '@angular/core';
import { EntertainmentType } from './models/entertainment.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  keys = Object.keys;
  types = EntertainmentType;
}
