import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchComponent } from './search.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchService } from './Search.service';
import { GeoLocation } from './../Models/GeoLocations';
import { WeatherService } from '../WeatherReport/weather.service';
import { WeatherModule } from '../WeatherReport/Weather.module';
@NgModule({
  imports: [CommonModule,FormsModule, ReactiveFormsModule,WeatherModule],
  declarations: [SearchComponent],
  exports: [SearchComponent]
})
export class SearchModule { }
