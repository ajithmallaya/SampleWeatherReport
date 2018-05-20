import { Component, ElementRef, OnInit } from '@angular/core';
import { City } from './Models/City';
import { GeoLocation } from './Models/GeoLocations';
import { Weather } from './Models/Weather';
import { SearchService } from './Search/Search.service';
import { Observable } from 'rxjs/Rx';
//import { FormControl, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
    constructor(public elementRef: ElementRef,
        public _searchService: SearchService,
        public cities: Observable<City>,private geolocation: Observable<GeoLocation>) {
      const native = this.elementRef.nativeElement;
      this.geolocation = native.getAttribute('Locations');
      _searchService.setLocation(this.geolocation);
        }
    
      
}
