import { Component, ElementRef, OnInit } from '@angular/core';
import { City } from './../Models/City';
import { GeoLocation } from './../Models/GeoLocations';
import { SearchService } from './../Search/Search.service';
import { Observable } from 'rxjs/Rx';
import { Weather } from './../Models/Weather';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
    constructor(public weather: Weather,public _searchService: SearchService,public cities: Observable<City>,private geolocation: GeoLocation) {
    }

    onCountrySearched(event) {
        this.cities = new Observable<City>();
        this._searchService.getCitiesByCountry(event.searchCountry)
          .subscribe(response => { this.geolocation = response.find(x=> x.Name == event.searchCountry); },
          Error => {
          });
      }
      
      onCitySelected(event) {
        const result = this._searchService.getWeatherReport(
          this.weatherForm.controls['searchForm'].get('searchCountry').value,
          event.selectedCity)
          .subscribe(response => {this.weather = response; },
          Error => {
          });
      }
    
      
}
