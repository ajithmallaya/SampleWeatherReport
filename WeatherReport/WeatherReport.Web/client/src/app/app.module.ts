import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import {
  LocationStrategy,
  HashLocationStrategy
} from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { HttpClientModule  } from '@angular/common/http';
//import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { SearchService } from './Search/Search.service';
import { SearchModule } from './Search/Search.module';
import { SearchComponent } from './Search/search.component';
import { WeatherComponent } from './WeatherReport/Weather.component';
import { WeatherService } from './WeatherReport/weather.service';

@NgModule({
    imports: [BrowserModule, HttpModule,HttpClientModule,FormsModule,SearchModule],
  declarations: [AppComponent],
  providers: [ SearchService,WeatherService],
  bootstrap: [AppComponent]
})
export class AppModule { }
