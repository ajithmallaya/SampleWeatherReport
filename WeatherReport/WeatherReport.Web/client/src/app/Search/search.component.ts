import { Component, Input, Output, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Weather } from './../Models/Weather';
import { City } from '../Models/City';
import { GeoLocation } from '../Models/GeoLocations';
import { SearchService } from './Search.service';
import { WeatherService } from '../WeatherReport/weather.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@Component({  
  selector: 'app-Search',
  templateUrl: './search.component.html',
  //styleUrls: []
})
export class SearchComponent implements OnInit {
@Input() locations : GeoLocation[];
 @Output() onCountrySearch = new EventEmitter();
  //searchForm: FormGroup;
 public citylist : string[];
 public locationlist: GeoLocation[];
 public selectedCountry: string;
 public selectedCity: string;
 public _weatherService: WeatherService;
 public _searchService: SearchService;

  titleAlert = 'This field is required';
  errorMessage: string;

  constructor(public weatherService: WeatherService,public searchService: SearchService) {
   this._weatherService = weatherService;
   this._searchService = searchService;
  }

  ngOnInit() {
    this.locationlist = JSON.parse(this.locations.toString());
    this.selectedCountry = '';
    this.selectedCity = '';
  }


  onSearch(country: string) {
    this.citylist  = [];
    var cities =  [];
    this.selectedCountry = country;
    for(var i=0,len = this.locationlist.length;i<len;i++){
      if(this.locationlist[i].Country.toString() == country)
      {
         for(var j=0,citlen = this.locationlist[i].Cities.length;j<citlen;j++){
           cities.push(this.locationlist[i].Cities[j].Name);
          
        }
      }
    }
    this.citylist = cities;
 }
  onCityChange(event:Event):void {
    const value:string = (<HTMLSelectElement>event.srcElement).value;
    this.selectedCity = value;
    const weather = this._searchService.getWeatherReport(this.selectedCountry,value)
   // console.log(this.stringify(weather));
    this._weatherService.getWeatherReport(this.stringify(weather));
  }
  stringify(o:any):string {
    return JSON.stringify(o);
  }

  
}

