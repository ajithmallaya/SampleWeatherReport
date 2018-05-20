import { NgModule } from '@angular/core';
import {
  LocationStrategy,
  HashLocationStrategy
} from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
//import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { SearchService } from './Search/Search.service';
import { SearchModule } from './Search/Search.module';
import { Observable } from 'rxjs/Rx';
import { SearchComponent } from './Search/search.component';
import { WeatherComponent } from './WeatherReport/Weather.component';
import { WeatherService } from './WeatherReport/weather.service';

@NgModule({
    imports: [BrowserModule, HttpModule,SearchModule],
  declarations: [AppComponent],
  providers: [ SearchService,WeatherService,Observable],
  bootstrap: [AppComponent]
})
export class AppModule { }
