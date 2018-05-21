import { Component, ElementRef, OnInit } from '@angular/core';
import { City } from './Models/City';
import { GeoLocation } from './Models/GeoLocations';
import { Weather } from './Models/Weather';
import { SearchService } from './Search/Search.service';
//import { FormControl, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
  public geolocations: GeoLocation[];
    constructor(public elementRef: ElementRef
       ) {
      const native = this.elementRef.nativeElement;
      this.geolocations = native.getAttribute('Locations');
     // _searchService.setLocation(this.geolocations);
     console.log(typeof(JSON.parse(this.geolocations.toString())));
        }
    
      
}
