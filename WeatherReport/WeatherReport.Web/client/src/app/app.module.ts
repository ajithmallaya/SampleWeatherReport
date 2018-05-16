import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { SelectModule } from 'angular2-select';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { SearchService } from './../Search/Search.service';
import { SearchComponent } from './../Search/search.component';
import { WeatherComponent } from './../WeatherReport/Weather.component';
import { WeatherService } from './../WeatherReport/weather.service';

@NgModule({
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    SelectModule
  ],
  declarations: [AppComponent,SearchComponent,WeatherComponent],
  providers: [SearchService,WeatherService],
  bootstrap: [AppComponent]
})
export class AppModule { }
