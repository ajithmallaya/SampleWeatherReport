import { GeoLocation } from '../Models/GeoLocations';
import { Weather } from '../Models/Weather';
import { Injectable } from '@angular/core';
import { Http, Response, Request, RequestMethod, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';

@Injectable()
export class SearchService {
 locations: Observable<GeoLocation>;
    constructor(private http: Http) { }

    setLocation(locationsArray: Observable<GeoLocation>) {
               this.locations = locationsArray;
       }

    
    getWeatherReport(country: string, city: string): Observable<Weather> {
        const url = 'http://localhost:4242/Weather/' + country + '/' + city;
        const headers = new Headers();
      
        return this.http.request(url)
            .map(response => response.json() as Weather);
    }

    handleError(error: Response) {
        return Observable.throw({
            status: error.status,
            statusText: error.statusText,
            message: 'error'
        });
    }
}